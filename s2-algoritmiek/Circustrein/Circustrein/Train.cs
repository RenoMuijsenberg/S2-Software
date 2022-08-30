using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Train
    {
        private List<Wagon> wagons = new List<Wagon>();

        public void SortAnimals(List<Animal> animals)
        {
            if (wagons.Count() == 0)
            {
                wagons.Add(new Wagon());
            }

            foreach (var animal in animals)
            {
                bool willFit = false;
                foreach (var wagon in wagons)
                {
                    if ((wagon.GetPoints() + animal.AnimalPoints()) < 11) //Kijk of het dier past qua grootte
                    {
                        //check if animal fits in wagon.
                        willFit = wagon.CheckIfAnimalFits(animal);

                    }

                    if (willFit)
                    {
                        wagon.AddAnimal(animal);
                    }
                }

                if (!willFit)
                {
                    wagons.Add(new Wagon());
                    wagons.Last().AddAnimal(animal);
                }
            }
        }

        public List<Wagon> GetWagons()
        {
            List<Wagon> copiedWagon = wagons;

            return copiedWagon;
        }
    }
}