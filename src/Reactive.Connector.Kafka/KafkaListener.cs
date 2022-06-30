using Confluent.Kafka;
using Newtonsoft.Json;
using Reactive.Interceptor.Core.Interfaces;
using Reactive.Kafka;
using Reactive.Provider.Kafka.Extension;

namespace Reactive.Provider.Kafka;

public class KafkaListener : ConsumerBase<string>
{
    private static IConfigurationProvider<KafkaConfig> _configuration;

    public static event Action<ConsumerMessage<string>> DataSource;
    public static KafkaListener Instance { get; set; }

    public KafkaListener(IConfigurationProvider<KafkaConfig> configuration)
    {
        _configuration = configuration;
        Instance = this;
    }
    public override Task OnConsume(ConsumerMessage<string> consumerMessage, Commit commit)
    {
        DataSource?.Invoke(consumerMessage);

        return Task.CompletedTask;
    }

    public static async Task Producer(object message)
    {
        if (Instance is null || _configuration is null)
            throw new NullReferenceException("The object KafkaListener has not yet been instantiated");

        var messageHandled = GetMessageHandled(message);
        
        await Instance.ProduceAsync(_configuration.GetBySink().Topic, messageHandled);    
    }

    public static string GetMessageHandled(object message)
    {
        if (message.GetType().FullName == typeof(ConsumerMessage<string>).FullName)
        {
            var consumerMessage = (ConsumerMessage<string>)message;
           return consumerMessage.Message;
        }
        if(message.GetType().IsSimpleType())
            return message.ToString();

        return JsonConvert.SerializeObject(message);
    }

    public override void OnProducerBuilder(ProducerConfig builder)
    {
        builder.BootstrapServers = _configuration.GetBySink().Host;
        base.OnProducerBuilder(builder);
    }

    public override void OnConsumerBuilder(ConsumerConfig builder)
    {
        builder.BootstrapServers = _configuration.GetBySource().Host;
        base.OnConsumerBuilder(builder);
    }

    public override void OnConsumerConfiguration(IConsumer<string, string> consumer)
    {
        consumer.Subscribe(_configuration.GetBySource().Topic);
        base.OnConsumerConfiguration(consumer);
    }
}
