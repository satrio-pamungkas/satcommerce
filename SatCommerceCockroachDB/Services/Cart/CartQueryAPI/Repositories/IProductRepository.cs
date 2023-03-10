using CartQueryAPI.Models;

namespace CartQueryAPI.Repositories;

public interface IProductRepository
{
    void Create(List<Product> data);
    void UpdateQuantity(Guid id, int quantity, bool isUndo);
    void UpdateSold(Guid id, int quantity);
    void Delete(Guid id);
    Product GetById(Guid id);
    IEnumerable<Product> GetAll();
}