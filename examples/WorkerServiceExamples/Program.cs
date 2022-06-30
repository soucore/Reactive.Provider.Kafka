using Reactive.Interceptor.Extensions;
using Reactive.Provider.Kafka.Extension;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddReactiveInterceptor();
        services.AddReactiveConnectorKafka();
    })
    .UseReactiveInterceptor()
    .Build();

await host.RunAsync();
