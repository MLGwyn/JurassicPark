using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class DinoDatabase
    {
        private List<Dino> dinos { get; set; } = new List<Dino>();
        public List<Dino> GetAllDinos()
        {
            return dinos;
        }
        public Dino FindADino(string dinoToFind)
        {
            Dino foundDino = dinos.FirstOrDefault(dino => dino.Name == dinoToFind);
            return foundDino;
        }
        public void AddDino(Dino newDino)
        {
            dinos.Add(newDino);
        }
        public void RemoveDino(Dino dinoToDelete)
        {
            dinos.Remove(dinoToDelete);
        }
    }
}

