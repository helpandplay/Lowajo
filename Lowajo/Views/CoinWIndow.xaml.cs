using Lowajo.ViewModel;
using System.Windows;

namespace Lowajo.Views
{
    /// <summary>
    /// CoinWIndow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CoinWIndow : Window
    {
        public CoinWIndow()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(CoinViewModel));
        }
    }
}
