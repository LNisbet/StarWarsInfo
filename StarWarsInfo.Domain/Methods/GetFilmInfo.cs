using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities;
using StarWarsInfo.Core.Entities.Interfaces;
using StarWarsInfo.Core.Exceptions;
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
                filmCollection.Add(BuildFilmInfoFromFilm(film, personRepo, planetRepo));
            }
            return filmCollection;
        }

        private static FilmInfo BuildFilmInfoFromFilm(Film film, IRepository<Person> personRepo, IRepository<Planet> planetRepo)
        {
            List<ICharacterInfo> characters = [];

            foreach (var character in film.Characters)
            {
                characters.Add(BuildCharecterFromUrl(character, personRepo, planetRepo));
            }

            List<string> planets = [];

            foreach (var planet in film.Planets)
            {
                planets.Add(GetPlanetNameFromUrl(planet, planetRepo));
            }

            return new FilmInfo(int.Parse(film.EpisodeId), film.Title, DateOnly.Parse(film.ReleaseDate), film.OpeningCrawl, planets, characters);
        }

        private static CharacterInfo BuildCharecterFromUrl(string url, IRepository<Person> personRepo, IRepository<Planet> planetRepo)
        {
            var charecter = personRepo.GetById(GetIdFromURL(url));
            return new CharacterInfo(charecter.Name, planetRepo.GetById(GetIdFromURL(charecter.Homeworld)).Name);
        }

        private static string GetPlanetNameFromUrl(string url, IRepository<Planet> planetRepo)
        {
            return planetRepo.GetById(GetIdFromURL(url)).Name;
        }

        private static int GetIdFromURL(string url)
        {
            string[] parts = url.Split('/');
            return int.Parse(parts[^2]); //Second to last part
        }
    }
}
