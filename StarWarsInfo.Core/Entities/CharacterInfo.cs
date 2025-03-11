using StarWarsInfo.Core.Entities.Interfaces;

namespace StarWarsInfo.Core.Entities
{
    public class CharacterInfo : ICharacterInfo
    {
        public string Name { get; }

        public string HomeWorld { get; }

        public CharacterInfo(string name, string homeworld) 
        { 
            Name = name;
            HomeWorld = homeworld;
        }  
    }
}
