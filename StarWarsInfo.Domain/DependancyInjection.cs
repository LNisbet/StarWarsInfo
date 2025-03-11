using Microsoft.Extensions.DependencyInjection;
using StarWarsApiCSharp;
using StarWarsInfo.Domain.Methods;
using StarWarsInfo.Domain.Methods.Interfaces;

namespace StarWarsInfo.Domain
{
    public class DependancyInjection
    {
        public static void ConfigureDependencies(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetFilmInfo, GetFilmInfo>();

            serviceCollection.AddTransient<IRepository<Film>, Repository<Film>>();
            serviceCollection.AddTransient<IRepository<Person>, Repository<Person>>();
            serviceCollection.AddTransient<IRepository<Planet>, Repository<Planet>>();
        }
    }
}
