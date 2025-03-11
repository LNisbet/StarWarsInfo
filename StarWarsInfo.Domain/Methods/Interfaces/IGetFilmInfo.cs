using StarWarsInfo.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.Domain.Methods.Interfaces
{
    public interface IGetFilmInfo
    {
        public IFilmInfo GetFilmInfo();
        public IFilmBasicInfo GetFilmBasicInfo();
        public IFilmDetailedInfo GetFilmDetailedInfo();
    }
}
