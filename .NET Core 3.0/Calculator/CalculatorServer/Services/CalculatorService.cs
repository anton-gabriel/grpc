using CalculatorServer.Actions;
using Generated;
using Grpc.Core;
using NLog;
using System;
using System.Threading.Tasks;

namespace CalculatorServer.Services
{
  internal sealed class CalculatorService : Generated.CalculatorService.CalculatorServiceBase
  {
    #region Logger
    private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
    #endregion
    public override async Task Calculate(IAsyncStreamReader<OperationRequest> requestStream, IServerStreamWriter<OperationResponse> responseStream, ServerCallContext context)
    {
      Calculator calculator = new Calculator();
      while (await requestStream.MoveNext())
      {
        var request = requestStream.Current;
        if (request.Operand != null)
        {
          calculator.AddOperand(request.Operand.Value);
        }
        if (calculator.CanCalculate)
        {
          if (request.Operation != OperationType.InvalidOperation)
          {
            Console.WriteLine($"The following operation will be calculated: {request.Operation}");
            await SendResultResponse(responseStream, calculator, request);
          }
          else
          {
            await SendOperationNeededResponse(responseStream);
          }
        }
        else
        {
          await SendOperandNeededResponse(responseStream);
        }
      }
    }

    #region Private methods
    private static async Task SendResultResponse(IServerStreamWriter<OperationResponse> responseStream, Calculator calculator, OperationRequest request)
    {
      await responseStream.WriteAsync(new OperationResponse()
      {
        Result = calculator.Calculate(request.Operation),
        Message = $"Calculated operation: {request.Operation}."
      });
    }

    private static async Task SendOperationNeededResponse(IServerStreamWriter<OperationResponse> responseStream)
    {
      await responseStream.WriteAsync(new OperationResponse()
      {
        Result = default,
        Message = "Please enter an operation type."
      });
    }

    private static async Task SendOperandNeededResponse(IServerStreamWriter<OperationResponse> responseStream)
    {
      await responseStream.WriteAsync(new OperationResponse()
      {
        Result = default,
        Message = "Please enter one more operand."
      });
    }
    #endregion
  }
}
