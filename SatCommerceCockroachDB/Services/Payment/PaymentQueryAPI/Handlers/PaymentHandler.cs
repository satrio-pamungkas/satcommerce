using System.Text.Json;
using PaymentQueryAPI.Models;
using PaymentQueryAPI.Repositories;

namespace PaymentQueryAPI.Handlers;

public class PaymentHandler : IPaymentHandler
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentHandler(IPaymentRepository paymentRepository)
    {
        this._paymentRepository = paymentRepository;
    }

    public void CreatePayment(string data)
    {
        List<Payment>? payments = JsonSerializer.Deserialize<List<Payment>>(data);
        this._paymentRepository.Create(payments!);
    }

    public void DeletePayment()
    {
        List<Payment> existingPayment = this._paymentRepository.GetAll().ToList();
        this._paymentRepository.DeleteAll(existingPayment);
    }
}