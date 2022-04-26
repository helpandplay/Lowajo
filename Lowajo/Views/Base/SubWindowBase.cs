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
    }
}
