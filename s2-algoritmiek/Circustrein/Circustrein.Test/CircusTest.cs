using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein.Test
{
    public class CircusTest
    {
        Circus circus = new();

        [Fact]
        public void Specify_Animals_In_Cirucs()
        {
            //Arrange
            List<Animal> animals = new List<Animal>
            {
                new(Food.Meat, Size.Big),
                new(Food.Meat, Size.Medium),
                new(Food.Meat, Size.Small),
                new(Food.Plant, Size.Big),
                new(Food.Plant, Size.Medium),
                new(Food.Plant, Size.Small)
            };

            //Act
            circus.AnimalsInCircus.AddRange(animals);

            //Assert
            Assert.True(circus.AnimalsInCircus.Any());
        }

        [Fact]
        public void Get_Animals_In_Circus()
        {
            //Arrange

            //Act

            //Assert
            Assert.NotNull(circus.AnimalsInCircus);
        }
    }
}
