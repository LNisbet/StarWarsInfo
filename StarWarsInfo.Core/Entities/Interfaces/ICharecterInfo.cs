using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsInfo.Core.Entities.Interfaces
{
    public interface ICharecterInfo
    {
        public string Name { get; }
        public string HomeWorld { get; }
    }
}
