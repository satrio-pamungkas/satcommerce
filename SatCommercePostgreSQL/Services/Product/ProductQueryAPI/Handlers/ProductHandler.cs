using ProductQueryAPI.Models;
using ProductQueryAPI.Repositories;
using ProductQueryAPI.Schemas;
using System.Text.Json;

namespace ProductQueryAPI.Handlers;

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
        UpdateProductRequest product = JsonSerializer.Deserialize<UpdateProductRequest>(data);
        this._productRepository.UpdateQuantity(product.Id, product.Quantity);
    }
}