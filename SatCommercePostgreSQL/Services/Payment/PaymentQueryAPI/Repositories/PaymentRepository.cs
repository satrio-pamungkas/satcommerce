using Microsoft.EntityFrameworkCore;
using PaymentQueryAPI.Data;
using PaymentQueryAPI.Models;

namespace PaymentQueryAPI.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly DataContext _context;

    public PaymentRepository(DataContext context)
    {
        this._context = context;
    }
    
    public void Create(List<Payment> request)
    {
        this._context.Payments.AddRange(request);
        this._context.SaveChanges();
    }

    public void DeleteSpecific(Guid id)
    {
        var payment = new Payment {Id = id};
        this._context.Payments.Remove(payment);
        this._context.SaveChanges();
    }

    public void DeleteAll(List<Payment> request)
    {
        foreach (var payment in request)
        {
            this._context.Payments.Remove(payment);
            this._context.SaveChanges();
        }
    }
    public IEnumerable<Payment> GetAll()
    {
        return this._context.Payments.AsNoTracking().ToList();
    }
    
}