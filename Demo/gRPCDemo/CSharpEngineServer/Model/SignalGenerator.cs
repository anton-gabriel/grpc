namespace CSharpEngineServer.Model
{
  using Audiodata;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public static class SignalGenerator
  {
    private const double _TwoPi = 2.0 * Math.PI;

    public static IEnumerable<AudioPoint> GenerateSinusoidalSignal(SignalRequest request)
    {
      return Enumerable
        .Range(0, (int)(request.SampleRate * request.Duration))
        .Select(n => new AudioPoint
        {
          X = (double)n / request.SampleRate,
          Y = request.Amplitude * Math.Sin((_TwoPi * request.Frequency * n / request.SampleRate) + request.PhaseShift)
        });
    }
  }
}
