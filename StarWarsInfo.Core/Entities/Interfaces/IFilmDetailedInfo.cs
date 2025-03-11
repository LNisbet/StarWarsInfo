using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.Core.Entities.Interfaces
{
    public interface IFilmDetailedInfo
    {
        public string OpeningCrawl { get; }
        public List<string> FeaturedPlanetNames { get; }
        public List<ICharacterInfo> FeaturedCharecters { get; }
    }
}
