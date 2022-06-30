using Microsoft.Extensions.DependencyInjection;
using Reactive.Kafka.Extensions;

namespace Reactive.Provider.Kafka.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReactiveConnectorKafka(this IServiceCollection services)
    {
        services.AddReactiveKafkaConsumerPerPartition<KafkaListener>((Provider, config) => { });
        services.AddTransient<KafkaProvider>();

        return services;
    }
}
