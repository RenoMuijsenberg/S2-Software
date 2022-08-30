using DePooleNationaleVlag;
using System;
using Xunit;

namespace DePoolseNationaleVlag.Test
{
    public class FlagTest
    {
        Flag flag;

        public FlagTest()
        {
            //Arrange
            flag = new Flag();
        }

        [Fact]
        public void Flag_Create_With_Random_Stones()
        {
            //Arrange
            
            //Act

            //Assert
            Assert.NotNull(flag);
            Assert.NotNull(flag.Stones);
        }

        [Fact]
        public void Flag_Get_All_Stones()
        {
            //Arrange
            string[] stones = flag.Stones;

            //Act

            //Assert
            Assert.NotNull(stones);
        }

        [Fact]
        public void Flag_Sort_Stones_Red_White()
        {
            //Arrange
            int lastRedIndex = 0;
            bool correctSorted = true;
            flag.SortFlag();

            //Act
            lastRedIndex = Array.LastIndexOf(flag.Stones, "red");

            for (int i = 0; i < lastRedIndex; i++)
            {
                if (flag.Stones[i] != "red")
                {
                    correctSorted = false;
                    break;
                }
            }

            if (correctSorted != false)
            {
                for (int i = lastRedIndex + 1; i < flag.Stones.Length; i++)
                {
                    if (flag.Stones[i] != "white")
                    {
                        correctSorted = false;
                        break;
                    }
                }
            }

            //Assert
            Assert.True(correctSorted);
        }
    }
}