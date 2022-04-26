using Lowajo.ViewModel;
using Lowajo.Views;
using System.Windows;

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
            CoinWindow coinWindow = new CoinWindow()
            {
                DataContext = App.Current.Services.GetService(typeof(CoinViewModel)),
            };
            coinWindow.SetPositionFromParentWindow(this);

            if(coinWindow.ShowDialog() == true)
            {

            }
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            //DataContext = App.Current.Services.GetService(typeof(SettingViewModel))
            SettingWindow settingWindow = new SettingWindow()
            {
            };
            settingWindow.Left = this.Left + this.Width - settingWindow.Width;
            settingWindow.Top = this.Top + this.Height - settingWindow.Height;

            if(settingWindow.ShowDialog() == true)
            {

            }
        }
    }
}
