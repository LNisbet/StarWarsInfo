using Moq;
using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities;
using StarWarsInfo.Core.Entities.Interfaces;
using StarWarsInfo.Core.Exceptions;
using StarWarsInfo.Domain.Methods;
using StarWarsInfo.Domain.Methods.Interfaces;
using System.Collections.ObjectModel;

namespace StarWarsInfo.Tests
{
    public class GetFilmInfo_Tests
    {
        #region Valid Entities
        static private readonly Film ValidFilm1 = new()
        {
            EpisodeId = "1",
            Title = "Film1",
            ReleaseDate = DateOnly.MinValue.ToString(),
            OpeningCrawl = "Text Text Text",
            Planets = [@"https://swapi.dev/api/planets/1/"],
            Characters = [@"https://swapi.dev/api/people/1/"]
        };

        static private readonly Film ValidFilm2 = new()
        {
            EpisodeId = "2",
            Title = "Film2",
            ReleaseDate = DateOnly.MinValue.ToString(),
            OpeningCrawl = "Text Text Text",
            Planets = [@"https://swapi.dev/api/planets/1/"],
            Characters = [@"https://swapi.dev/api/people/1/"]
        };

        static private readonly Person ValidPerson1 = new()
        {
            Name = "Person1",
            Homeworld = @"https://swapi.dev/api/planets/1/"
        };

        static private readonly Planet ValidPlanet1 = new()
        {
            Name = "Planet1"
        };

        static private readonly string ExpectedPlanetName1 = ValidPlanet1.Name;

        static private readonly ICharacterInfo ExpectedCharecter1 = new CharacterInfo(ValidPerson1.Name, ExpectedPlanetName1);

        static private readonly IFilmInfo ExpectedFilm1 = new FilmInfo
        (
            int.Parse(ValidFilm1.EpisodeId),
            ValidFilm1.Title,
            DateOnly.Parse(ValidFilm1.ReleaseDate),
            ValidFilm1.OpeningCrawl,
            [ValidPlanet1.Name],
            [ExpectedCharecter1]
        );
        static private readonly IFilmInfo ExpectedFilm2 = new FilmInfo
        (
            int.Parse(ValidFilm2.EpisodeId),
            ValidFilm2.Title,
            DateOnly.Parse(ValidFilm2.ReleaseDate),
            ValidFilm2.OpeningCrawl,
            [ValidPlanet1.Name],
            [ExpectedCharecter1]
        );
        #endregion

        private const int ExpectedId = 1;
        private readonly Mock<IRepository<Planet>> _mockPlanetRepo;
        private readonly Mock<IRepository<Person>> _mockPersonRepo;

        public GetFilmInfo_Tests()
        {
            _mockPlanetRepo = new Mock<IRepository<Planet>>();
            _mockPlanetRepo
                .Setup(repo => repo.GetById(ExpectedId))
                .Returns(ValidPlanet1);

            _mockPersonRepo = new Mock<IRepository<Person>>();
            _mockPersonRepo
                .Setup(repo => repo.GetById(ExpectedId))
                .Returns(ValidPerson1);
        }

        public static IEnumerable<object[]> FilmTestData()
        {
            yield return new object[]
            {
            new List<Film> { ValidFilm1 },
            new ObservableCollection<IFilmInfo> { ExpectedFilm1 }
            };

            yield return new object[]
            {
            new List<Film> { ValidFilm2 },
            new ObservableCollection<IFilmInfo> { ExpectedFilm2 }
            };

            yield return new object[]
            {
            new List<Film> { ValidFilm1, ValidFilm2 },
            new ObservableCollection<IFilmInfo> { ExpectedFilm1, ExpectedFilm2 }
            };
        }

        [Theory]
        [MemberData(nameof(FilmTestData))]
        public void ValidFilms_ReturnsFilms(ICollection<Film> validFilms, ObservableCollection<IFilmInfo> expectedFilms)
        {
            // Arrange
            var mockFilmRepo = new Mock<IRepository<Film>>();
            mockFilmRepo
                .Setup(repo => repo.GetEntities(1, 10))
                .Returns(validFilms);

            IGetFilmInfo _getFilmInfo = new GetFilmInfo();

            // Act
            var result = _getFilmInfo.GetAllFilmInfo(mockFilmRepo.Object, _mockPersonRepo.Object, _mockPlanetRepo.Object);

            // Assert
            Assert.Equivalent(expectedFilms, result);
        }

        [Fact]
        public void BlankFilm_ThrowsException()
        {
            // Arrange
            var mockFilmRepo = new Mock<IRepository<Film>>();
            mockFilmRepo
                .Setup(repo => repo.GetEntities(1, 10))
                .Returns([]); ;
            IGetFilmInfo _getFilmInfo = new GetFilmInfo();

            // Act and Assert
            Assert.Throws<NoFilmsException>(() => _getFilmInfo.GetAllFilmInfo(mockFilmRepo.Object, _mockPersonRepo.Object, _mockPlanetRepo.Object));
        }
        [Fact]
        public void NullFilm_ThrowsException()
        {
            // Arrange
            var mockFilmRepo = new Mock<IRepository<Film>>();
            mockFilmRepo
                .Setup(repo => repo.GetEntities(1, 10))
                .Returns([null]); ;
            IGetFilmInfo _getFilmInfo = new GetFilmInfo();

            // Act and Assert
            Assert.Throws<NullReferenceException>(() => _getFilmInfo.GetAllFilmInfo(mockFilmRepo.Object, _mockPersonRepo.Object, _mockPlanetRepo.Object));
        }
    }
}