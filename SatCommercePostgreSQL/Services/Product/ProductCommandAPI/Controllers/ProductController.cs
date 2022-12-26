using Microsoft.AspNetCore.Mvc;
using ProductCommandAPI.Models;
using ProductCommandAPI.Producers;
using ProductCommandAPI.Schemas;
using System.Text.Json;

namespace ProductCommandAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductTopicProducer _productTopicProducer;
    private readonly string _topic;
    
    public ProductController(IConfiguration configuration)
    {
        this._productTopicProducer = new ProductTopicProducer(configuration);
        this._topic = configuration.GetValue<string>("Kafka:Topic:Product");
    }

    [HttpPost]
    public IActionResult CreateProduct(List<ProductRequest> request)
    {
        List<Product> payload = new List<Product>();
        foreach (var productRequest in request)
        {
            var newData = new Product
            {
                Id = Guid.NewGuid(),
                Name = productRequest.Name,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity
            };
            payload.Add(newData);
        }
        string jsonString = JsonSerializer.Serialize(payload);
        this._productTopicProducer.EmitMessage(this._topic, jsonString);
        
        return Ok(payload);
    }
}