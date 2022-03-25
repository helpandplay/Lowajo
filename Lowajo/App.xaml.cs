using Lowajo.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Lowajo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public ResourceDictionary ThemeDictionary => Resources.MergedDictionaries[0];
        public new static App Current => (App)Application.Current;
        public App()
        {
            Services = SetServices();
            this.InitializeComponent();
        }

        private static IServiceProvider SetServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(typeof(MainViewModel));

            return services.BuildServiceProvider();
        }

        public void ChangeTheme(Uri themePath)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = themePath });
        }
    }
}
