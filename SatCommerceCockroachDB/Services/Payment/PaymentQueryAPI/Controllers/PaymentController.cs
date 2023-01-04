using Microsoft.AspNetCore.Mvc;
using PaymentQueryAPI.Repositories;

namespace PaymentQueryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentController(IPaymentRepository paymentRepository)
    {
        this._paymentRepository = paymentRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = this._paymentRepository.GetAll();
        return Ok(data);
    }
}