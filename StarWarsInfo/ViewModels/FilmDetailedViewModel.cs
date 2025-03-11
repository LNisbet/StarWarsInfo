using StarWarsInfo.Core.Entities.Interfaces;
using StarWarsInfo.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.ViewModels
{
    public class FilmDetailedViewModel : Base_VM
    {
        public List<ICharacterInfo>? FeaturedCharecters => _SelectedFilmStore.SelectedFilm?.FeaturedCharecters;
        public List<string>? FeaturedPlanets => _SelectedFilmStore.SelectedFilm?.FeaturedPlanetNames;
        public string? OpeningCrawl => _SelectedFilmStore.SelectedFilm?.OpeningCrawl;


        private readonly SelectedFilmStore _SelectedFilmStore;

        public FilmDetailedViewModel(SelectedFilmStore selectedFilmStore)
        {
            _SelectedFilmStore = selectedFilmStore;
            _SelectedFilmStore.SelectedFilmChanged += OnSelectedFilmChanged;
        }
        private void OnSelectedFilmChanged()
        {
            OnPropertyChanged(nameof(FeaturedCharecters));
            OnPropertyChanged(nameof(FeaturedPlanets));
            OnPropertyChanged(nameof(OpeningCrawl));
        }
    }
}
