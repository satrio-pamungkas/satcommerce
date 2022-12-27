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
                Price = product.Price,
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
                ProductName = product.Name,
                TotalPrice = product.Price * product.Quantity
            };
            carts.Add(newData);
        }
        
        this._cartRepository.Create(carts);
    }

    public void DeleteSpecificCart(string data)
    {
        DeleteCartRequest request = JsonSerializer.Deserialize<DeleteCartRequest>(data);
        this._cartRepository.DeleteSpecific(request.CartId);
    }
}