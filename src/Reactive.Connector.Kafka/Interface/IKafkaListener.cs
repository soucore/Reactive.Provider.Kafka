using Reactive.Kafka;

namespace Reactive.Provider.Kafka.Interface;

public interface IKafkaListener
{
    event Action<ConsumerMessage<string>> DataSource;
    Task Producer(object message);
}