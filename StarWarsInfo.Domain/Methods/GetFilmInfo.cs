using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities.Interfaces;
using StarWarsInfo.Core.Exceptions;
using StarWarsInfo.Domain.Methods.HelperMethods;
using StarWarsInfo.Domain.Methods.Interfaces;
using System.Collections.ObjectModel;

namespace StarWarsInfo.Domain.Methods
{
    public class GetFilmInfo : IGetFilmInfo
    {
        public ObservableCollection<IFilmInfo> GetAllFilmInfo(IRepository<Film> filmRepo, IRepository<Person> personRepo, IRepository<Planet> planetRepo)
        {
            ObservableCollection<IFilmInfo> filmCollection = [];

            var films = filmRepo.GetEntities();

            if (!films.Any())
                throw new NoFilmsException();

            foreach (var film in films)
            {
                filmCollection.Add(BuildEntities.BuildFilmInfoFromFilm(film, personRepo, planetRepo));
            }
            return filmCollection;
        }
    }
}
