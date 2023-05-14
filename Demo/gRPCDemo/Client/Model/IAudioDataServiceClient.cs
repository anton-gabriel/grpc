namespace Client.Model
{
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public record Point(double X, double Y);
  public record Chunk(IEnumerable<Point> Data);

  public interface IAudioDataClient
  {
    Chunk GenerateSignal(double frequency, double amplitude, double phaseShift, double duration, int sampleRate);
    IAsyncEnumerable<Chunk> StreamAudioInput(double durationInSeconds);
    Task<Chunk> SendChunksAsync(IAsyncEnumerable<Chunk> chunks);
    IAsyncEnumerable<Chunk> StreamChunksAsync(IAsyncEnumerable<Chunk> chunks);
  }
}
