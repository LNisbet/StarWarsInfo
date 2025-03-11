using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.Domain.Methods.Interfaces
{
    public interface IGetFilmInfo
    {
        public ObservableCollection<IFilmInfo> GetAllFilmInfo(IRepository<Film> filmRepo, IRepository<Person> personRepo, IRepository<Planet> planetRepo);
    }
}
