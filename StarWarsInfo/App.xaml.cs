using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace StarWarsInfo
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();

            StarWarsInfo.DependencyInjection.ConfigureDependencies(serviceCollection);
            StarWarsInfo.Domain.DependancyInjection.ConfigureDependencies(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
