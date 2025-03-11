using StarWarsApiCSharp;
using StarWarsInfo.Core.Entities.Interfaces;
using StarWarsInfo.Domain.Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.Domain.Methods
{
    public class GetFilmInfo : IGetFilmInfo
    {
        public ObservableCollection<IFilmInfo> GetAllFilmInfo(IRepository<Film> filmRepo)
        {
            throw new NotImplementedException();
        }
    }
}
