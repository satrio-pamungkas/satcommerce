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
    private readonly string _topic;

    public PaymentController(IConfiguration configuration)
    {
        this._paymentTopicProducer = new PaymentTopicProducer(configuration);
        this._topic = configuration.GetValue<string>("Kafka:Topic:Payment");
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

        string jsonString = JsonSerializer.Serialize(payload);
        this._paymentTopicProducer.CreatePayment(this._topic,jsonString);

        return Ok(payload);
    }
}