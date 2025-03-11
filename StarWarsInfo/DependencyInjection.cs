using Microsoft.Extensions.DependencyInjection;
using StarWarsInfo.ViewModels;
using StarWarsInfo.ViewModels.HelperClasses;

namespace StarWarsInfo
{
    public class DependencyInjection
    {
        public static void ConfigureDependencies(ServiceCollection serviceCollection)
        {
            // Register ViewModels
            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddSingleton<FilmOverViewModel>();
            serviceCollection.AddSingleton<FilmDetailedViewModel>();

            // Register Stores
            serviceCollection.AddSingleton<SelectedFilmStore>();

            // Register Views
            serviceCollection.AddSingleton<MainWindow>(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });
        }
    }
}
