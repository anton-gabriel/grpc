namespace CalculatorServer.Utils.Messages
{
  internal static class LoggerMessages
  {
    public static string ServiceRequestMessage(string service, string host, string peer)
    {
      return $"New request from {peer}, at host {host} for service: {service}.";
    }

    public static string ServerClosedMessage(string host, int peer)
    {
      return $"Server closed ({host}:{peer}).";
    }

    public static string ServerStartedMessage(string host, int peer)
    {
      return $"Server started ({host}:{peer}).";
    }
  }
}
