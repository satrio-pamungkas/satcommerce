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

    public void DeleteSpecific(Guid id)
    {
        var cart = new Cart {Id = id};
        this._context.Carts.Remove(cart);
        this._context.SaveChanges();
    }

    public IEnumerable<Cart> GetAll()
    {
        return this._context.Carts.AsNoTracking().ToList();
    }
}