using System.Text.Json;
using CartQueryAPI.Repositories;
using CartQueryAPI.Models;
using CartQueryAPI.Schemas;

namespace CartQueryAPI.Handlers;

public class CartHandler : ICartHandler
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public CartHandler(ICartRepository cartRepository, IProductRepository productRepository)
    {
        this._cartRepository = cartRepository;
        this._productRepository = productRepository;
    }

    public void CreateCart(string data)
    {
        List<CreateCartRequest> payload = JsonSerializer.Deserialize<List<CreateCartRequest>>(data);
        Console.WriteLine(payload[0].Quantity);
        List<Cart> carts = new List<Cart>();
        
        foreach (var item in payload)
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
        
        Console.WriteLine(carts[0].Quantity);
        this._cartRepository.Create(carts);
    }

    public void DeleteSpecificCart(string data)
    {
        DeleteCartRequest request = JsonSerializer.Deserialize<DeleteCartRequest>(data);
        var payload = this._cartRepository.GetAllSpecific(request.CartId).ToList();
        this._cartRepository.DeleteSpecific(payload);
    }
}
