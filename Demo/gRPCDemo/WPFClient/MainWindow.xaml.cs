﻿namespace WPFClient
{
  using System.Windows;
  using WPFClient.ViewModel;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow(MainViewModel viewModel)
    {
      DataContext = viewModel;
      InitializeComponent();
    }
  }
}
