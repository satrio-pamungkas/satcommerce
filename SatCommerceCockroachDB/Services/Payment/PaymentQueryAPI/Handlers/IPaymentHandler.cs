namespace PaymentQueryAPI.Handlers;

public interface IPaymentHandler
{
    void CreatePayment(string data);
    void DeletePayment();
}