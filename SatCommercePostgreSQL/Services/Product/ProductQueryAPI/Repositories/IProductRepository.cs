using ProductQueryAPI.Models;

namespace ProductQueryAPI.Repositories;

public interface IProductRepository
{
    void Create(List<Product> data);
    void UpdateQuantity(Guid id, int quantity, bool isUndo);
    void UpdateSold(Guid id, int quantity);
    Product GetBySlug(string slug);
    IEnumerable<Product> GetAll();
}