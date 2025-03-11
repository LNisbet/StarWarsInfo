using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsInfo.Core.Entities.Interfaces;

namespace StarWarsInfo.ViewModels.HelperClasses
{
    public class SelectedFilmStore
    {
        private IFilmInfo? selectedFilm;
        public IFilmInfo? SelectedFilm
        {
            get => selectedFilm;
            set
            {
                if (selectedFilm != value)
                {
                    selectedFilm = value;
                    OnSelectedFilmChanged();
                }
            }
        }

        public event Action? SelectedFilmChanged;

        private void OnSelectedFilmChanged()
        {
            SelectedFilmChanged?.Invoke();
        }
    }
}
