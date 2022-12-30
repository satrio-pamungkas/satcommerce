using System.Text.Json;
using CartCommandAPI.Schemas;
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
        List<CreateCartRequest> payload = new List<CreateCartRequest>();
        Guid uuid = Guid.NewGuid();
        foreach (var cartRequest in request)
        {
            var newData = new CreateCartRequest
            {
                CartId = uuid,
                ProductId = cartRequest.ProductId,
                Quantity = cartRequest.Quantity
            };
            payload.Add(newData);
        }
        
        Console.WriteLine(payload[0].Quantity);
        string cartString = JsonSerializer.Serialize(payload);
        string productString = JsonSerializer.Serialize(request);
        this._cartTopicProducer.CreateCart(_cartTopic, cartString);
        this._productTopicProducer.UpdateProduct(_productTopic, productString);

        return Ok(request);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSpecificCart(string id)
    {
        this._cartTopicProducer.DeleteSpecificCart(_cartTopic, id);
        return Ok();
    }

}