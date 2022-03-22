using System.Windows;
using System.Windows.Controls;

namespace Lowajo.Themes.Components
{
    /// <summary>
    /// ImageButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageButton : Button
    {
        private readonly static DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source), typeof(string), typeof(ImageButton),
                new PropertyMetadata(string.Empty));
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public ImageButton()
        {
            InitializeComponent();
        }

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
    }
}
