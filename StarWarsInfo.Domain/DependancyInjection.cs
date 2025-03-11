using Microsoft.Extensions.DependencyInjection;
using StarWarsApiCSharp;
using StarWarsInfo.Domain.Methods;
using StarWarsInfo.Domain.Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
