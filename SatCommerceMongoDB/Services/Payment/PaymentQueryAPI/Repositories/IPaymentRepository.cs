using PaymentQueryAPI.Models;

namespace PaymentQueryAPI.Repositories;

public interface IPaymentRepository
{
    void Create(List<Payment> data);
    void DeleteSpecific(String id);
    void DeleteAll();
    IEnumerable<Payment> GetAll();
}