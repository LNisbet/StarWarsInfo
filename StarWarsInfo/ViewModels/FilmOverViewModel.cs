using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities.Interfaces;
using StarWarsInfo.Domain.Methods.Interfaces;
using StarWarsInfo.ViewModels.HelperClasses;
using System.Collections.ObjectModel;

namespace StarWarsInfo.ViewModels
{
    public class FilmOverViewModel : Base_VM
    {
        public ObservableCollection<IFilmInfo> FilmList { get; }

        private readonly SelectedFilmStore _selectedFilmStore;

        public IFilmInfo SelectedFilm
        {
            set
            {
                _selectedFilmStore.SelectedFilm = value;
            }
        }

        public FilmOverViewModel(IGetFilmInfo getFilmInfo, SelectedFilmStore selectedFilmStore, IRepository<Film> filmRepo, IRepository<Person> personRepo, IRepository<Planet> planetRepo)
        {
            FilmList = getFilmInfo.GetAllFilmInfo(filmRepo, personRepo, planetRepo);
            _selectedFilmStore = selectedFilmStore;
        }
    }
}
