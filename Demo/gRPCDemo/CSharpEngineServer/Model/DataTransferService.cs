namespace CSharpEngineServer.Model
{
  using Audiodata;
  using Grpc.Core;
  using Microsoft.Extensions.Logging;
  using System.Threading.Tasks;

  internal class DataTransferService : DataTransfer.DataTransferBase
  {
    private readonly ILogger<DataTransferService> _Logger;

    public DataTransferService(ILogger<DataTransferService> logger)
    {
      _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override Task<AudioChunk> GenerateSignal(SignalRequest request, ServerCallContext context)
    {
      //Cum functioneaza RPC-urile
      //pentru fiecare call un thread nou? Cate call-uri pot avea in paralel?
      //Cum este tradus un call catre server si invers (catre client)?
      //Viteza
      //
      _Logger.LogInformation($"{nameof(GenerateSignal)} request: [input] = {{Request}}", request);
      IEnumerable<AudioPoint> signal = SignalGenerator.GenerateSinusoidalSignal(request);
      var chunk = new AudioChunk();
      chunk.Points.AddRange(signal);
      return Task.FromResult(chunk);
    }

    public override async Task StreamAudioInput(AudioStreamRequest request, IServerStreamWriter<AudioChunk> responseStream, ServerCallContext context)
    {
      _Logger.LogInformation($"{nameof(StreamAudioInput)} request: [input] = {{Request}}", request);

      IEnumerable<AudioPoint> signal = SignalGenerator.GenerateSinusoidalSignal(new SignalRequest()
      {
        Frequency = 1.0,
        Amplitude = 1.0,
        PhaseShift = 0.0,
        Duration = request.DurationInSeconds,
        SampleRate = 50
      });


      int index = 0;
      IEnumerable<AudioPoint> points = signal.Skip(index).Take(50);

      while (points.Any())
      {
        var chunk = new AudioChunk();
        chunk.Points.AddRange(points);
        index += 50;
        points = signal.Skip(index).Take(50);
        await Task.Delay(400);
        await responseStream.WriteAsync(chunk);
      }
    }

    public override async Task<AudioChunk> SendChunks(IAsyncStreamReader<AudioChunk> requestStream, ServerCallContext context)
    {
      var receivedChunks = new List<AudioChunk>();

      await foreach (var chunk in requestStream.ReadAllAsync())
      {
        receivedChunks.Add(chunk);
      }

      return receivedChunks.First();
    }

    public override async Task StreamChunks(IAsyncStreamReader<AudioChunk> requestStream, IServerStreamWriter<AudioChunk> responseStream, ServerCallContext context)
    {
      await foreach (var requestChunk in requestStream.ReadAllAsync())
      {
        var chunkToSend = requestChunk;
        await responseStream.WriteAsync(chunkToSend);
      }
    }
  }
}
