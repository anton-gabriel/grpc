using Generated;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace CalculatorClient
{
    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            const string host = "localhost";
            const int port = 50051;
            const string stopMessage = "stop";

            var channel = new Channel($"{host}:{port}", ChannelCredentials.Insecure);
            var client = new CalculatorService.CalculatorServiceClient(channel);


            Console.WriteLine("Client sending request: ");

            using (var call = client.Calculate())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var response = call.ResponseStream.Current;
                        Console.WriteLine("Received: " + response);
                    }
                });

                string input = Console.ReadLine();
                while (input != stopMessage)
                {
                    try
                    {
                        if (double.TryParse(input, out double operand))
                        {
                            await call.RequestStream.WriteAsync(new OperationRequest() { Operand = new Operand() { Value = operand } });
                        }
                        else if (Enum.TryParse(input, out OperationType operation))
                        {
                            await call.RequestStream.WriteAsync(new OperationRequest() { Operation = operation });
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    input = Console.ReadLine();
                }
                await call.RequestStream.CompleteAsync();
                await responseReaderTask;
            }
        }
    }
}
