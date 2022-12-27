using PaymentQueryAPI.Models;

namespace PaymentQueryAPI.Repositories;

public interface IPaymentRepository
{
    void Create(List<Payment> data);
    void DeleteSpecific(Guid id);
    void DeleteAll(List<Payment> data);
    IEnumerable<Payment> GetAll();
}