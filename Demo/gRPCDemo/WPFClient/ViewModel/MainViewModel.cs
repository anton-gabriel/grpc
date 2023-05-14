namespace WPFClient.ViewModel
{
  using Client.Model;
  using LiveChartsCore;
  using LiveChartsCore.Defaults;
  using LiveChartsCore.SkiaSharpView;
  using LiveChartsCore.SkiaSharpView.Painting;
  using Prism.Commands;
  using Prism.Mvvm;
  using SkiaSharp;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Threading.Tasks;
  using System.Windows.Input;

  public sealed class MainViewModel : BindableBase
  {
    private readonly IAudioDataClient _AudioDataClient;
    private readonly ObservableCollection<ObservablePoint> _ObservableValues;

    public MainViewModel(IAudioDataClient audioDataClient)
    {
      _AudioDataClient = audioDataClient ?? throw new System.ArgumentNullException(nameof(audioDataClient));

      _ObservableValues = new ObservableCollection<ObservablePoint>();
      Series = new ObservableCollection<ISeries>
      {
        new LineSeries<ObservablePoint>
        {
          Values = _ObservableValues,
          GeometryFill = null,
          Fill = null,
          GeometrySize = 5.0,
        },
      };

      StreamAudioCommand = new DelegateCommand(async () => await StreamAudioInput());
      GeneratePointsCommand = new DelegateCommand(GeneratePoints);
      ResetCommand = new DelegateCommand(ResetPoints);
    }

    private void ResetPoints()
    {
      _ObservableValues.Clear();
    }

    private async Task StreamAudioInput()
    {
      var lastPoint = _ObservableValues.LastOrDefault();
      double offset = lastPoint != null ? lastPoint.X.Value : 0.0;
      await foreach (Chunk receivedChunk in _AudioDataClient.StreamAudioInput(10.0))
      {
        System.Windows.Application.Current.Dispatcher.Invoke(() =>
        {
          foreach (var point in receivedChunk.Data)
          {
            _ObservableValues.Add(new ObservablePoint(point.X + offset, point.Y));
          }
        });
      }
    }

    private void GeneratePoints()
    {
      var points = GetDataPoints();
      foreach (var point in points)
      {
        _ObservableValues.Add(point);
      }
    }

    private ObservableCollection<ObservablePoint> GetDataPoints()
    {
      var signal = _AudioDataClient.GenerateSignal(frequency: 1, amplitude: 1.0, phaseShift: 0.0, duration: 5.0, sampleRate: 50);
      return new ObservableCollection<ObservablePoint>(signal.Data.Select(p => new ObservablePoint(p.X, p.Y)));
    }

    public ObservableCollection<ISeries> Series { get; set; }

    public ICommand StreamAudioCommand { get; }
    public ICommand GeneratePointsCommand { get; }
    public ICommand ResetCommand { get; }
  }
}
