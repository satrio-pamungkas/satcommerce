using CartQueryAPI.Models;

namespace CartQueryAPI.Repositories;

public interface ICartRepository
{
    void Create(List<Cart> data);
    void DeleteSpecific(List<Cart> data);
    IEnumerable<Cart> GetAll();
    IEnumerable<Cart> GetAllSpecific(Guid id);
}