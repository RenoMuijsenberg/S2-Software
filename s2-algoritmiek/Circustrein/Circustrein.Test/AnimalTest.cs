using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Circustrein.Test
{
    public class AnimalTest
    {
        Animal animal;

        public AnimalTest()
        {
            animal = new Animal(Food.Meat, Size.Big);
        }

        [Fact]
        public void Create_New_Animal_Test()
        {
            //Arrange
            Animal newAnimal = new Animal(Food.Meat, Size.Big);

            //Act

            //Assert
            Assert.NotNull(newAnimal);
        }

        [Fact]
        public void Get_Animal_Food_Test()
        {
            //Arrange

            //Act

            //Assert
            Assert.True(animal.Food == Food.Meat);
        }

        [Fact]
        public void Get_Animal_Size_Test()
        {
            //Arrange

            //Act

            //Assert
            Assert.True(animal.Size == Size.Big);
        }

        [Fact]
        public void Get_Animal_Points_Test()
        {
            //Arrange

            //Act

            //Assert
            Assert.True(animal.AnimalPoints() == (int)Size.Big);
        }
    }
}
