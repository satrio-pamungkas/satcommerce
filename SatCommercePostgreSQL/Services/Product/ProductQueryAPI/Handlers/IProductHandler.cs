using ProductQueryAPI.Models;
using ProductQueryAPI.Schemas;

namespace ProductQueryAPI.Handlers;

public interface IProductHandler
{
    void CreateProduct(string data);
    void UpdateProductQuantity(string data);
    void CancelUpdateProductQuantity(string data);
    void UpdateProductSold(string data);
    void DeleteProduct(string data);
}