using Confluent.Kafka;
using CartQueryAPI.Handlers;

namespace CartQueryAPI.Consumers;

public class ProductTopicConsumer : BackgroundService
{
    private readonly string _topic;
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ProductTopicConsumer(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
    {
        var consumerConfig = new ConsumerConfig();
        configuration.GetSection("Kafka:ConsumerSettings").Bind(consumerConfig);
        this._topic = configuration.GetValue<string>("Kafka:Topic:Product");
        this._consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        this._serviceScopeFactory = serviceScopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() => StartConsumerLoop(stoppingToken), stoppingToken);
    }
    
    private void StartConsumerLoop(CancellationToken cancellationToken)
    {
        this._consumer.Subscribe(this._topic);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<IProductHandler>();
                var payload = this._consumer.Consume(cancellationToken);
                var header = payload.Message.Headers[0].Key;
                var data = payload.Message.Value;

                switch (header)
                {
                    case "ProductCreated":
                        handler.CreateProduct(data);
                        break;
                    case "ProductQuantityUpdated":
                        handler.UpdateProductQuantity(data);
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (ConsumeException e)
            {
                // Consumer errors should generally be ignored (or logged) unless fatal.
                Console.WriteLine($"Consume error: {e.Error.Reason}");

                if (e.Error.IsFatal)
                {
                    // https://github.com/edenhill/librdkafka/blob/master/INTRODUCTION.md#fatal-consumer-errors
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e}");
                break;
            }
        }
    }

    public override void Dispose()
    {
        this._consumer.Close();
        this._consumer.Dispose();
        
        base.Dispose();
    }
}