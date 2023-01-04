using System.Text.Json;
using CartQueryAPI.Repositories;
using CartQueryAPI.Models;
using CartQueryAPI.Schemas;
using CartQueryAPI.Producers;

namespace CartQueryAPI.Handlers;

public class CartHandler : ICartHandler
{
    private readonly ProductTopicProducer _productTopicProducer;
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly string _productTopic;

    public CartHandler(
        ICartRepository cartRepository, 
        IProductRepository productRepository, 
        IConfiguration configuration)
    {
        this._cartRepository = cartRepository;
        this._productRepository = productRepository;
        this._productTopicProducer = new ProductTopicProducer(configuration);
        this._productTopic = this._productTopic = configuration.GetValue<string>("Kafka:Topic:Product");
    }

    public void CreateCart(string data)
    {
        List<CreateCartRequest>? payload = JsonSerializer.Deserialize<List<CreateCartRequest>>(data);
        List<Cart> carts = new List<Cart>();
        
        foreach (var item in payload!)
        {
            Product product = this._productRepository.GetById(item.ProductId);
            var newData = new Cart
            {
                Id = Guid.NewGuid(),
                CartId = item.CartId,
                ProductId = item.ProductId,
                Brand = product.Brand,
                Slug = product.Slug,
                Price = product.Price,
                Quantity = item.Quantity,
                ImageUrl = product.ImageUrl,
                ProductName = product.Name,
                TotalPrice = product.Price * item.Quantity
            };
            carts.Add(newData);
        }
        
        this._cartRepository.Create(carts);
    }

    public void DeleteSpecificCart(string data)
    {
        List<Cart> payload;
        
        // Deleted manually
        if (data.Length == 36)
        {
            Guid uuid = new Guid(data);
            payload = this._cartRepository.GetAllSpecific(uuid).ToList();
            List<UpdateProductRequest> newProduct = new List<UpdateProductRequest>();
            foreach (var item in payload)
            {
                var newData = new UpdateProductRequest
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                newProduct.Add(newData);
            }

            string jsonString = JsonSerializer.Serialize(newProduct);
            this._productTopicProducer.UpdateProductQuantity(_productTopic, jsonString);
            
        }
        // Deleted by payment trigger
        else
        {
            DeleteCartRequest? request = JsonSerializer.Deserialize<DeleteCartRequest>(data);
            payload = this._cartRepository.GetAllSpecific(request!.CartId).ToList();
            List<UpdateProductRequest> newProduct = new List<UpdateProductRequest>();
            foreach (var item in payload)
            {
                var newData = new UpdateProductRequest
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                newProduct.Add(newData);
            }
            
            string jsonString = JsonSerializer.Serialize(newProduct);
            this._productTopicProducer.UpdateProductSold(_productTopic, jsonString);
        }
        
        this._cartRepository.DeleteSpecific(payload);
    }
}
