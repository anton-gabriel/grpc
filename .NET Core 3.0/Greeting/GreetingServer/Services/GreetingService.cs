using Generated;
using GreetingServer.Utils.Messages;
using Grpc.Core;
using NLog;
using System.Threading.Tasks;

namespace GreetingServer.Services
{
    internal sealed class GreetingService : Generated.GreetingService.GreetingServiceBase
    {
        #region Logger
        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
        #endregion

        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            //Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(Greet), host: context.Host, peer: context.Peer));
            return Task.FromResult(new GreetingResponse() { Message = $"Hello, {request.SenderName}." });
        }
    }
}
