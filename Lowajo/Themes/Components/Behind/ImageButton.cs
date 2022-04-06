﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lowajo.Themes.Components.Behind
{
    public class ImageButton : Button
    {
        private readonly static DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source), typeof(string), typeof(ImageButton),
        new PropertyMetadata(string.Empty));
        private readonly static DependencyProperty ClickCommandProperty =
            DependencyProperty.Register(nameof(ClickCommand), typeof(ICommand), typeof(ImageButton),
                new PropertyMetadata(null));

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        public ICommand ClickCommand
        {
            get => (ICommand)GetValue(ClickCommandProperty);
            set => SetValue(ClickCommandProperty, value);
        }
    }
}
