using System.Windows;

namespace Lowajo.Views.Base
{
  public class SubWindowBase : Window
  {
    private readonly Window? parent;
    private SubWindowBase()
    {
      this.Deactivated += SubWindowBase_Deactivated;
      this.Unloaded += SubWindowBase_Unloaded;
    }

    private void SubWindowBase_Deactivated(object? sender, System.EventArgs e)
    {
      //DelayClose();
    }

    private async void DelayClose()
    {
      await Dispatcher.InvokeAsync(() => this.Close());
    }

    public SubWindowBase(Window parent) : this()
    {
      this.parent = parent;
      this.Loaded += SubWindowBase_Loaded;
    }

    private void SubWindowBase_Loaded(object sender, RoutedEventArgs e)
    {
      if(parent != null)
      {
        this.Left = parent.Left + parent.Width - this.Width;
        this.Top = parent.Top + parent.Height;
      }
    }

    private void SubWindowBase_Unloaded(object sender, RoutedEventArgs e)
    {
      this.Loaded -= SubWindowBase_Loaded;
      this.Deactivated -= SubWindowBase_Deactivated;
      this.Unloaded -= SubWindowBase_Unloaded;
    }
  }
}
