using CartQueryAPI.Models;
using CartQueryAPI.Repositories;
using CartQueryAPI.Schemas;
using System.Text.Json;

namespace CartQueryAPI.Handlers;

public class ProductHandler : IProductHandler
{
    private readonly IProductRepository _productRepository;

    public ProductHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    
    public void CreateProduct(string data)
    {
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
        this._productRepository.Create(products);
    }

    public void UpdateProductQuantity(string data)
    {
        List<UpdateProductRequest> product = JsonSerializer.Deserialize<List<UpdateProductRequest>>(data);
        foreach (var item in product)
        {
            this._productRepository.UpdateQuantity(item.ProductId, item.Quantity);
        }
    }
}