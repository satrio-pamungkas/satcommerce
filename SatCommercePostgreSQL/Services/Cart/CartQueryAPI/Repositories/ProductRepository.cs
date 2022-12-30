using Microsoft.EntityFrameworkCore;
using CartQueryAPI.Data;
using CartQueryAPI.Models;

namespace CartQueryAPI.Repositories;

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

    public void UpdateQuantity(Guid id, int quantity, bool isUndo)
    {
        var data = this._context.Products.First(a => a.Id == id);
        var previousQuantity = data.Quantity;
        if (isUndo == true)
            data.Quantity = previousQuantity + quantity;
        else
            data.Quantity = previousQuantity - quantity;
        
        this._context.SaveChanges();
    }

    public void UpdateSold(Guid id, int quantity)
    {
        var data = this._context.Products.First(a => a.Id == id);
        var previousSold = data.Sold;
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