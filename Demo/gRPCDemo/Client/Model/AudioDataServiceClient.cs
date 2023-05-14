namespace Client.Model
{
  using Audiodata;
  using Grpc.Core;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public sealed class AudioDataClient : IAudioDataClient
  {
    private readonly DataTransfer.DataTransferClient _Client;

    public AudioDataClient(DataTransfer.DataTransferClient client)
    {
      _Client = client;
    }

    public Chunk GenerateSignal(double frequency, double amplitude, double phaseShift, double duration, int sampleRate)
    {
      var response = _Client.GenerateSignal(new SignalRequest()
      {
        Frequency = frequency,
        Amplitude = amplitude,
        PhaseShift = phaseShift,
        Duration = duration,
        SampleRate = sampleRate
      });
      return new Chunk(response.Points.Select(p => new Point(p.X, p.Y)));
    }

    public async IAsyncEnumerable<Chunk> StreamAudioInput(double durationInSeconds)
    {
      var request = new AudioStreamRequest() { DurationInSeconds = durationInSeconds };
      var call = _Client.StreamAudioInput(request);
      await foreach (var response in call.ResponseStream.ReadAllAsync())
      {
        yield return new Chunk(response.Points.Select(p => new Point(p.X, p.Y)));
      }
    }

    public async Task<Chunk> SendChunksAsync(IAsyncEnumerable<Chunk> chunks)
    {
      var call = _Client.SendChunks();
      await foreach (var chunk in chunks)
      {
        var request = new AudioChunk { Points = { chunk.Data.Select(p => new AudioPoint { X = p.X, Y = p.Y }) } };
        await call.RequestStream.WriteAsync(request);
      }
      await call.RequestStream.CompleteAsync();
      var response = await call.ResponseAsync;
      return new Chunk(response.Points.Select(p => new Point(p.X, p.Y)));
    }

    public async IAsyncEnumerable<Chunk> StreamChunksAsync(IAsyncEnumerable<Chunk> chunks)
    {
      using var call = _Client.StreamChunks();

      var responseReaderTask = Task.Run(async () =>
      {
        var chunkList = new List<Chunk>();
        await foreach (var response in call.ResponseStream.ReadAllAsync())
        {
          chunkList.Add(new Chunk(response.Points.Select(p => new Point(p.X, p.Y))));
        }
        return chunkList;
      });

      await foreach (var chunk in chunks)
      {
        var request = new AudioChunk { Points = { chunk.Data.Select(p => new AudioPoint { X = (float)p.X, Y = (float)p.Y }) } };
        await call.RequestStream.WriteAsync(request);
      }

      await call.RequestStream.CompleteAsync();

      var responseChunks = await responseReaderTask;
      foreach (var chunk in responseChunks)
      {
        yield return chunk;
      }
    }
  }
}
