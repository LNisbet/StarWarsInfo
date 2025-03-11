using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities;
using StarWarsInfo.Core.Entities.Interfaces;

namespace StarWarsInfo.Domain.Methods.HelperMethods
{
    internal class BuildEntities
    {
        internal static FilmInfo BuildFilmInfoFromFilm(Film film, IRepository<Person> personRepo, IRepository<Planet> planetRepo)
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

        internal static CharacterInfo BuildCharecterFromUrl(string url, IRepository<Person> personRepo, IRepository<Planet> planetRepo)
        {
            var charecter = personRepo.GetById(GetIdFromURL(url));
            return new CharacterInfo(charecter.Name, planetRepo.GetById(GetIdFromURL(charecter.Homeworld)).Name);
        }

        internal static string GetPlanetNameFromUrl(string url, IRepository<Planet> planetRepo)
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
