using CartQueryAPI.Models;

namespace CartQueryAPI.Repositories;

public interface IProductRepository
{
    void Create(List<Product> data);
    void UpdateQuantity(Guid id, int quantity);
    Product GetById(Guid id);
    IEnumerable<Product> GetAll();
}