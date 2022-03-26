using Lowajo.ViewModel.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lowajo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool isMouseEnter = false;
        private Window? view = null;

        public MainViewModel()
        {

        }

        /// <summary>
        /// Window가 로드되면 항상 위를 적용한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is Window window)
            {
                window.Topmost = true;
            }
        }
        /// <summary>
        /// 마우스가 컨트롤 안으로 들어오면 마우스 포인터를 Grab으로 바꾼다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!isMouseEnter) isMouseEnter = true;
            if (sender is Grid imageContainer)
            {
                object CursorGrab = Application.Current.TryFindResource("CursorGrab");
                if (CursorGrab == null || CursorGrab is not TextBlock tb) return;
                imageContainer.Cursor = tb.Cursor;
            }
        }
        /// <summary>
        /// 마우스가 컨트롤 밖으로 나가면 마우스 포인터를 Arrow로 바꾼다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (isMouseEnter) isMouseEnter = false;
            if (isMouseEnter && sender is Window window)
            {
                window.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 마우스를 클릭하면 마우스 포인터를 Grabbing으로 바꾸고 드래그한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            if (sender is not Grid imageContainer) return;

            if (isMouseEnter)
            {
                object CursorGrabbing = Application.Current.TryFindResource("CursorGrabbing");
                if (CursorGrabbing != null && CursorGrabbing is TextBlock tb)
                    imageContainer.Cursor = tb.Cursor;
            }

            bool isFindView = false;
            if (view is null)
            {
                DependencyObject findElement = LogicalTreeHelper.GetParent(imageContainer);
                while (!isFindView)
                {
                    if (findElement is Window find)
                    {
                        view = find;
                        isFindView = true;
                    }
                    else
                    {
                        findElement = LogicalTreeHelper.GetParent(findElement);
                    }
                }
            }

            view?.DragMove();
        }
        /// <summary>
        /// 마우스 클릭을 떼면 마우스 포인터를 Grab으로 바꾼다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Released) return;
            if (sender is not Grid imageContainer) return;
            if (!isMouseEnter) return;

            object CursorGrab = Application.Current.TryFindResource("CursorGrab");
            if (CursorGrab != null && CursorGrab is TextBlock tb)
                imageContainer.Cursor = tb.Cursor;
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is not Window window) return;
            if (!isMouseEnter) return;
            if (e.LeftButton != MouseButtonState.Pressed) return;
            System.Diagnostics.Debug.WriteLine($"" +
                $"ML: {SystemParameters.WorkArea.Left}, WL: {window.Left}");
        }
    }
}
