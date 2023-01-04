using CartQueryAPI.Data;
using CartQueryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartQueryAPI.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DataContext _context;

    public CartRepository(DataContext context)
    {
        this._context = context;
    }

    public void Create(List<Cart> data)
    {
        this._context.Carts.AddRange(data);
        this._context.SaveChanges();
    }

    public void DeleteSpecific(List<Cart> data)
    {
        this._context.Carts.RemoveRange(data);
        this._context.SaveChanges();
    }

    public IEnumerable<Cart> GetAll()
    {
        return this._context.Carts.AsNoTracking().ToList();
    }

    public IEnumerable<Cart> GetAllSpecific(Guid id)
    {
        return this._context.Carts.AsQueryable().Where(p => p.CartId == id).ToList();
    }
}