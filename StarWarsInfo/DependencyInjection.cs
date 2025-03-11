using Microsoft.Extensions.DependencyInjection;
using StarWarsInfo.ViewModels;
using StarWarsInfo.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
