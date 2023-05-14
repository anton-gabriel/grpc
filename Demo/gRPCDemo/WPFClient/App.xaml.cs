namespace WPFClient
{
  using Client.Model;
  using System.Windows;
  using WPFClient.ViewModel;

  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      Window window = new MainWindow(new MainViewModel(Clients.CreateClient()));
      window.Show();

      base.OnStartup(e);
    }
  }
}
