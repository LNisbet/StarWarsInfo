namespace StarWarsInfo.Core.Entities.Interfaces
{
    public interface IFilmDetailedInfo
    {
        public string OpeningCrawl { get; }
        public List<string> FeaturedPlanetNames { get; }
        public List<ICharacterInfo> FeaturedCharecters { get; }
    }
}
