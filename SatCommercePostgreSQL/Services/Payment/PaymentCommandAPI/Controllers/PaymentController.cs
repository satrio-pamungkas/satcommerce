using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PaymentCommandAPI.Models;
using PaymentCommandAPI.Producers;
using PaymentCommandAPI.Schemas;

namespace PaymentCommandAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentTopicProducer _paymentTopicProducer;
    private readonly CartTopicProducer _cartTopicProducer;
    private readonly string _paymentTopic;
    private readonly string _cartTopic;

    public PaymentController(IConfiguration configuration)
    {
        this._paymentTopicProducer = new PaymentTopicProducer(configuration);
        this._cartTopicProducer = new CartTopicProducer(configuration);
        this._paymentTopic = configuration.GetValue<string>("Kafka:Topic:Payment");
        this._cartTopic = configuration.GetValue<string>("Kafka:Topic:Cart");
    }

    [HttpPost]
    public IActionResult CreatePayment(List<PaymentRequest> request)
    {
        List<Payment> payload = new List<Payment>();
        foreach (var paymentRequest in request)
        {
            var newData = new Payment
            {
                Id = Guid.NewGuid(),
                Name = paymentRequest.Name,
                Type = paymentRequest.Type,
                IdNumber = paymentRequest.IdNumber,
                ImageUrl = paymentRequest.ImageUrl
            };
            payload.Add(newData);
        }

        string paymentPayload = JsonSerializer.Serialize(payload);
        this._paymentTopicProducer.CreatePayment(this._paymentTopic,paymentPayload);

        return Ok(payload);
    }

    [HttpPost("Cart")]
    public IActionResult SendPayment(MakePaymentRequest request)
    {
        var payload = new DeleteCartRequest {CartId = request.CartId};
        string jsonString = JsonSerializer.Serialize(payload);
        this._cartTopicProducer.DeleteCart(this._cartTopic,jsonString);

        var response = new SuccessResponse
        {
            CartId = request.CartId,
            Description = "Payment is success",
            Valid = true
        };

        return Ok(response);
    }
    
    [HttpDelete]
    public IActionResult DeleteAll()
    {
        this._paymentTopicProducer.DeletePayment(_paymentTopic);
        return Ok();
    }
}