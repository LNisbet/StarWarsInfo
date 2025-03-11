using StarWarsInfo.ViewModels.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.ViewModels
{
    internal class MainWindowViewModel : Base_VM
    {
        private readonly FilmOverViewModel _overViewModel;
        public FilmOverViewModel OverViewModel => _overViewModel;

        private readonly FilmDetailedViewModel _detailedViewModel;
        public FilmDetailedViewModel DetailedViewModel => _detailedViewModel;


        public MainWindowViewModel(FilmOverViewModel overViewModel, FilmDetailedViewModel detailedViewModel)
        {
            _overViewModel = overViewModel;
            _detailedViewModel = detailedViewModel;
        }
    }
}
