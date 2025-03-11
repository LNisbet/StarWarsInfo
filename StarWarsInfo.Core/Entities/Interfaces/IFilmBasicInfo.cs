namespace StarWarsInfo.Core.Entities.Interfaces
{
    public interface IFilmBasicInfo
    {
        public int Id { get; }
        public string Title { get; }
        public DateOnly ReleaseDate { get; }
    }
}
