using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.Core.Entities.Interfaces
{
    public interface IFilmBasicInfo
    {
        public int Id { get; }
        public string Title { get; }
        public DateOnly ReleaseDate { get; }
    }
}
