using Lowajo.ViewModel.Base;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows;
using System.Windows.Input;

namespace Lowajo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool isMouseEnter = false;
        private bool isClicking = false;
        private readonly FrameworkElement controlCursorGrab;

        public ICommand OnClickSettingCommand { get; private set; }

        public MainViewModel()
        {
            OnClickSettingCommand = new RelayCommand(OnClickSetting);
            controlCursorGrab = (FrameworkElement)Application.Current.TryFindResource("CursorGrab");
        }

        private void OnClickSetting()
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
        /// 마우스가 컨트롤 안으로 들어오면 컨트롤을 포커싱한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (isClicking ||
                isMouseEnter ||
                sender is not FrameworkElement element) return;

            isMouseEnter = true;
            element.Cursor = controlCursorGrab.Cursor;
        }
        /// <summary>
        /// 마우스가 컨트롤 밖으로 나가면 마우스 포인터를 Arrow로 바꾼다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (isClicking ||
                !isMouseEnter ||
                sender is not FrameworkElement element) return;

            isMouseEnter = false;
            element.Cursor = Cursors.Arrow;
        }
        /// <summary>
        /// 마우스를 클릭하면 마우스 포인터를 Grabbing으로 바꾼다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isClicking ||
                !isMouseEnter ||
                e.LeftButton != MouseButtonState.Pressed
                ) return;
            if (sender is not FrameworkElement element) return;

            isClicking = true;
            object CursorGrabbing = Application.Current.TryFindResource("CursorGrabbing");
            element.Cursor = (CursorGrabbing as FrameworkElement)?.Cursor;

            element.Dispatcher.BeginInvoke(new Action(() =>
            {
                Application.Current.MainWindow.DragMove();
                if (e.LeftButton == MouseButtonState.Released) OnMouseUp(sender, e);
            }));
        }
        /// <summary>
        /// 마우스 클릭을 떼면 마우스 포인터를 Grab으로 바꾼다.
        /// 이 이벤트는 뷰와 연결되지 않는다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!isClicking ||
                e.LeftButton != MouseButtonState.Released ||
                sender is not FrameworkElement element) return;

            element.Cursor = controlCursorGrab.Cursor;
            isClicking = false;
        }
    }
}
