using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities.Interfaces;
using System.Collections.ObjectModel;

namespace StarWarsInfo.Domain.Methods.Interfaces
{
    public interface IGetFilmInfo
    {
        public ObservableCollection<IFilmInfo> GetAllFilmInfo(IRepository<Film> filmRepo, IRepository<Person> personRepo, IRepository<Planet> planetRepo);
    }
}
