namespace Client.Model
{
  using Audiodata;
  using Grpc.Core;
  using Grpc.Net.Client;

  public static class Clients
  {
    public static IAudioDataClient CreateClient()
    {
      var channel = CreateChannel("http://localhost:50051");
      var client = new DataTransfer.DataTransferClient(channel);
      return new AudioDataClient(client);
    }

    private static GrpcChannel CreateChannel(string address)
    {
      var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions()
      {
        Credentials = ChannelCredentials.Insecure
      });
      return channel;
    }
  }
}
