using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Circustrein.Test
{
    public class WagonTest
    {
        [Fact]
        public void Add_Animal_To_Wagon()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Meat, Size.Big);

            wagon.AddAnimal(firstAnimal);

            Assert.Equal(wagon.GetPoints(), (int)firstAnimal.Size);
        }

        [Fact]
        public void Get_Wagon_Points()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Meat, Size.Big);

            wagon.AddAnimal(firstAnimal);

            Assert.True(wagon.GetPoints() > 0);
        }

        [Fact]
        public void Add_Two_Big_Meat_Eaters_To_Wagon()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Meat, Size.Big);
            Animal secondAnimal = new Animal(Food.Meat, Size.Big);

            wagon.AddAnimal(firstAnimal);
            bool willFit = wagon.CheckIfAnimalFits(secondAnimal);

            Assert.False(willFit);
        }

        [Fact]
        public void Add_Smaller_Meat_Eater_To_Wagon()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Meat, Size.Big);
            Animal secondAnimal = new Animal(Food.Meat, Size.Medium);
            Animal thirdAnimal = new Animal(Food.Meat, Size.Small);

            wagon.AddAnimal(firstAnimal);
            bool willFitMedium = wagon.CheckIfAnimalFits(secondAnimal);
            bool willFitSmall = wagon.CheckIfAnimalFits(thirdAnimal);

            Assert.False(willFitMedium);
            Assert.False(willFitSmall);
        }

        [Fact]
        public void Add_Two_Big_Plant_Eaters_To_Wagon()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Plant, Size.Big);
            Animal secondAnimal = new Animal(Food.Plant, Size.Big);

            wagon.AddAnimal(firstAnimal);
            bool willFit = wagon.CheckIfAnimalFits(secondAnimal);

            Assert.True(willFit);
        }

        [Fact]
        public void Add_Smaller_Plant_Eaters_To_Wagon()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Plant, Size.Big);
            Animal secondAnimal = new Animal(Food.Plant, Size.Big);
            Animal thirdAnimal = new Animal(Food.Plant, Size.Big);

            wagon.AddAnimal(firstAnimal);
            bool willFitMedium = wagon.CheckIfAnimalFits(secondAnimal);
            bool willFitSmall = wagon.CheckIfAnimalFits(thirdAnimal);

            Assert.True(willFitMedium);
            Assert.True(willFitSmall);
        }

        [Fact]
        public void Add_Smaller_Plant_Eaters_With_Big_Meat_Eater_To_Wagon()
        {
            var wagon = new Wagon();
            Animal firstAnimal = new Animal(Food.Meat, Size.Big);
            Animal secondAnimal = new Animal(Food.Plant, Size.Big);
            Animal thirdAnimal = new Animal(Food.Plant, Size.Big);

            wagon.AddAnimal(firstAnimal);
            bool willFitMedium = wagon.CheckIfAnimalFits(secondAnimal);
            bool willFitSmall = wagon.CheckIfAnimalFits(thirdAnimal);

            Assert.False(willFitMedium);
            Assert.False(willFitSmall);
        }
    }
}
