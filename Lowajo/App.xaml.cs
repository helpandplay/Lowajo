using Lowajo.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lowajo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public Collection<ResourceDictionary> MergedDictionary => Resources.MergedDictionaries;
        public new static App Current => (App)Application.Current;
        public App()
        {
            Services = SetServices();
            this.InitializeComponent();
            this.ChangeTheme(new Uri("/Themes/Resources/Theme_Abrelshud.xaml", UriKind.Relative));
        }

        private static IServiceProvider SetServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(typeof(MainViewModel));

            return services.BuildServiceProvider();
        }

        public void ChangeTheme(Uri themePath)
        {
            MergedDictionary.RemoveAt(0);
            MergedDictionary.Insert(0, new ResourceDictionary() { Source = themePath });
        }
    }
}
