using Microsoft.AspNetCore.Mvc;
using ProductCommandAPI.Models;
using ProductCommandAPI.Producers;
using ProductCommandAPI.Schemas;
using ProductCommandAPI.Utils;
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
            var uuid = Guid.NewGuid();
            var newData = new Product
            {
                Name = productRequest.Name,
                Slug = SlugGenerator.Slug(productRequest.Name!, uuid),
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
                Description = productRequest.Description,
                Brand = productRequest.Brand,
                Rating = productRequest.Rating,
                Sold = productRequest.Sold,
                Weight = productRequest.Weight,
                ImageUrl = productRequest.ImageUrl
            };
            payload.Add(newData);
        }
        string jsonString = JsonSerializer.Serialize(payload);
        this._productTopicProducer.CreateProduct(this._topic, jsonString);
        
        return Ok(payload);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteProduct(string id)
    {
        if (id.Length == 36)
        {
            this._productTopicProducer.DeleteProduct(this._topic, id);
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
}