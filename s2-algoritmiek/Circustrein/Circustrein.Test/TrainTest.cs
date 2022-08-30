using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Circustrein.Test
{
    public class TrainTest
    {      
        [Fact]
        public void Sort_Animals_And_Get_Wagons()
        {
            Train train = new Train();

            List<Animal> animals = new List<Animal>
            {
                new(Food.Plant, Size.Big),
                new(Food.Meat, Size.Big)
            };

            train.SortAnimals(animals);

            List<Wagon> wagons = train.GetWagons();

            Assert.True(wagons.Any());
        }
    }
}
