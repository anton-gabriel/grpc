using Generated;
using Grpc.Core;
using System;

namespace GreetingClient
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
           
            using(var endpoint = new ClientEndpoint())
            {
                var request = new GreetingRequest
                {
                    Message = "Hi",
                    SenderName = "Gabi"
                };

                Console.WriteLine("Client sending request: ");
                Console.WriteLine($"{request} {System.Environment.NewLine}");


                using var response = endpoint.Client.GreetAsync(request);
                Console.WriteLine("Client received response: ");
                Console.WriteLine(response.ResponseAsync.Result);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
