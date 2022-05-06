using System.Windows;
using Lowajo.ViewModel;
using Lowajo.Views;

namespace Lowajo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = App.Current.Services.GetService(typeof(MainViewModel));

      this.Left = ( SystemParameters.PrimaryScreenWidth - this.Width ) / 2;
      this.Top = 0;
    }

    private void CoinButton_Click(object sender, RoutedEventArgs e)
    {
      var coinWindow = new CoinWindow(this);
      coinWindow.Show();

    }

    private void SettingButton_Click(object sender, RoutedEventArgs e)
    {
      //DataContext = App.Current.Services.GetService(typeof(SettingViewModel))
      var settingWindow = new SettingWindow(this)
      {
      };
      settingWindow.Left = this.Left + this.Width - settingWindow.Width;
      settingWindow.Top = this.Top + this.Height - settingWindow.Height;

      settingWindow.Show();

    }
  }
}
