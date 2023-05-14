using Audiodata;
using CSharpEngineServer.Model;
using Grpc.Core;
using Microsoft.Extensions.Logging;

const int Port = 50051;

var loggerFactory = LoggerFactory.Create(builder =>
{
  builder.AddConsole();
});

ILogger<DataTransferService> logger = loggerFactory.CreateLogger<DataTransferService>();

// Build and start the gRPC server
var server = new Server
{
  Services = { DataTransfer.BindService(new DataTransferService(logger)) },
  Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
};
server.Start();

Console.WriteLine($"{nameof(DataTransferService)} server listening on port {Port}");
Console.WriteLine("Press any key to stop the server...");
Console.ReadKey();

server.ShutdownAsync().Wait();