using StarWarsInfo.Core.Entities.Interfaces;

namespace StarWarsInfo.Core.Entities
{
    public class CharecterInfo : ICharecterInfo
    {
        public string Name { get; }

        public string HomeWorld { get; }

        public CharecterInfo(string name, string homeworld) 
        { 
            Name = name;
            HomeWorld = homeworld;
        }  
    }
}
