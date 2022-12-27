namespace CartQueryAPI.Handlers;

public interface IProductHandler
{
    void CreateProduct(string data);
    void UpdateProductQuantity(string data);
}