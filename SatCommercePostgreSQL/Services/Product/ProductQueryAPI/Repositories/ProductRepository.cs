using Microsoft.EntityFrameworkCore;
using ProductQueryAPI.Data;
using ProductQueryAPI.Models;

namespace ProductQueryAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        this._context = context;
    }

    public void Create(List<Product> data)
    {
        this._context.Products.AddRange(data);
        this._context.SaveChanges();
    }

    public void UpdateQuantity(Guid id, int quantity)
    {
        var data = this._context.Products.First(a => a.Id == id);
        var previousQuantity = data.Quantity;
        var previousSold = data.Sold;
        data.Quantity = previousQuantity - quantity;
        data.Sold = previousSold + quantity;
        this._context.SaveChanges();
    }

    public Product GetById(Guid id)
    {
        return this._context.Products
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Product> GetAll()
    {
        return this._context.Products.AsNoTracking().ToList();
    }
}