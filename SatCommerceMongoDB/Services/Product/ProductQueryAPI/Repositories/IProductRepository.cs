using ProductQueryAPI.Models;

namespace ProductQueryAPI.Repositories;

public interface IProductRepository
{
    void Create(List<Product> data);
    void UpdateQuantity(string id, int quantity, bool isUndo);
    void UpdateSold(string id, int quantity);
    void Delete(string id);
    Product GetBySlug(string slug);
    IEnumerable<Product> GetAll();
}