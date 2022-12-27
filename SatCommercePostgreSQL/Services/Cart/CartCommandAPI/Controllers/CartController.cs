using System.Text.Json;
using CartCommandAPI.Schemas;
using CartCommandAPI.Models;
using CartCommandAPI.Producers;
using Microsoft.AspNetCore.Mvc;

namespace CartCommandAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ProductTopicProducer _productTopicProducer;
    private readonly CartTopicProducer _cartTopicProducer;
    private readonly string _cartTopic;
    private readonly string _productTopic;
    
    public CartController(IConfiguration configuration)
    {
        this._productTopicProducer = new ProductTopicProducer(configuration);
        this._cartTopicProducer = new CartTopicProducer(configuration);
        this._cartTopic = configuration.GetValue<string>("Kafka:Topic:Cart");
        this._productTopic = configuration.GetValue<string>("Kafka:Topic:Product");
    }

    [HttpPost]
    public IActionResult CreateCart(List<CartRequest> request)
    {
        string jsonString = JsonSerializer.Serialize(request);
        this._cartTopicProducer.CreateCart(_cartTopic, jsonString);
        this._productTopicProducer.UpdateProduct(_productTopic, jsonString);

        return Ok(request);
    }

}