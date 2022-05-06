using System.Windows;
using Lowajo.ViewModel;
using Lowajo.Views.Base;

namespace Lowajo.Views
{
  /// <summary>
  /// CoinWIndow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class CoinWindow : SubWindowBase
  {
    public CoinWindow(Window parent) : base(parent)
    {
      InitializeComponent();
      DataContext = App.Current.Services.GetService(typeof(CoinViewModel));
    }
  }
}
