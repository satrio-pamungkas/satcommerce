using CartQueryAPI.Models;

namespace CartQueryAPI.Repositories;

public interface ICartRepository
{
    void Create(List<Cart> data);
    void DeleteSpecific(string id);
    IEnumerable<Cart> GetAll();
    IEnumerable<Cart> GetAllSpecific(string id);
}