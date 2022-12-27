using CartQueryAPI.Models;

namespace CartQueryAPI.Repositories;

public interface ICartRepository
{
    void Create(List<Cart> data);
    void DeleteSpecific(Guid id);
    IEnumerable<Cart> GetAll();
}