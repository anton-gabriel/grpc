namespace GreetingClient
{
    using Generated;
    using Grpc.Core;
    using System;

    internal sealed class ClientEndpoint
        : IDisposable
    {
        public ClientEndpoint()
        {
            const string Host = "localhost";
            const int Port = 50051;

            this.channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);
            Client = new GreetingService.GreetingServiceClient(channel);
        }

        private readonly Channel channel;
        public GreetingService.GreetingServiceClient Client { get; }

        public void Dispose()
        {
            this.channel.ShutdownAsync().Wait();
        }
    }
}
