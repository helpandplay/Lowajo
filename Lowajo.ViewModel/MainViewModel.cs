using Lowajo.ViewModel.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lowajo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool isCtrlKeyDown = false;
        private bool isMouseEnter = false;

        public MainViewModel()
        {

        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is Window view)
            {
                view.Topmost = true;
            }
        }
        public void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!isMouseEnter) isMouseEnter = true;
        }

        public void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (isMouseEnter) isMouseEnter = false;
        }

        public void OnCtrlKeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)) return;

            isCtrlKeyDown = false;
            if (isMouseEnter && sender is Window view)
            {
                view.Cursor = Cursors.Arrow;
            }
        }

        public void OnCtrlKeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)) return;

            isCtrlKeyDown = true;
            if (isMouseEnter && sender is Window view)
            {
                object CursorGrab = Application.Current.TryFindResource("CursorGrab");
                if (CursorGrab == null || CursorGrab is not TextBlock tb) return;
                view.Cursor = tb.Cursor;
            }
        }

        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            if (!isCtrlKeyDown) return;
            if (sender is not Window view) return;

            if (isCtrlKeyDown && isMouseEnter)
            {
                object CursorGrabbing = Application.Current.TryFindResource("CursorGrabbing");
                if (CursorGrabbing != null && CursorGrabbing is TextBlock tb)
                    view.Cursor = tb.Cursor;
            }
            view.DragMove();
        }
    }
}
