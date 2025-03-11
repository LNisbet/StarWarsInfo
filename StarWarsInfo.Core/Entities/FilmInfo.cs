using StarWarsInfo.Core.Entities.Interfaces;

namespace StarWarsInfo.Core.Entities
{
    public class FilmInfo : IFilmInfo
    {
        public int Id { get; }

        public string Title { get; }

        public DateOnly ReleaseDate { get; }

        public string OpeningCrawl { get; }

        public List<string> FeaturedPlanetNames { get; }

        public List<ICharecterInfo> FeaturedCharecters { get; }

        public FilmInfo(int id, string title, DateOnly releaseDate, string openingCrawl, List<string> feaaturedPlaneNames, List<ICharecterInfo> featuredCharecters)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            OpeningCrawl = openingCrawl;
            FeaturedPlanetNames = feaaturedPlaneNames;
            FeaturedCharecters = featuredCharecters;
        }
    }
}
