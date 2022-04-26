using System.Windows;

namespace Lowajo.Views.Base
{
    public class SubWindowBase : Window
    {
        public void SetPositionFromParentWindow(Window parent)
        {
            this.Left = parent.Left + parent.Width - this.Width;
            this.Top = parent.Top + parent.Height;
        }

        public SubWindowBase()
        {
            this.LostFocus += SubWindowBase_LostFocus;
            this.Unloaded += SubWindowBase_Unloaded;
        }

        private void SubWindowBase_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= SubWindowBase_Unloaded;
            this.LostFocus -= SubWindowBase_LostFocus;
        }

        private void SubWindowBase_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
