namespace CartQueryAPI.Handlers;

public interface ICartHandler
{
    void CreateCart(string data);
    void DeleteSpecificCart(string data);
}