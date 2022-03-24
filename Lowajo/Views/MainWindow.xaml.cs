using Lowajo.ViewModel;
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

            this.Left = (SystemParameters.PrimaryScreenWidth - this.Width) / 2;
            this.Top = 0;
        }
    }
}
