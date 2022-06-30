using Reactive.Interceptor.Core;
using Reactive.Interceptor.Providers;

namespace Reactive.Provider.Kafka;

public class KafkaProvider : ProviderBase
{
    public override string ProviderName => "kafka";

    public override async Task ExecuteSourceAsync(CancellationToken cancellationToken)
    {
        KafkaListener.DataSource += (message) => _ = EmitBySource(message);
        await Task.CompletedTask;
    }

    public override async Task<Response> Sink(object data)
    {
        await KafkaListener.Producer(data);
        return new Response("Success!");
    }
}