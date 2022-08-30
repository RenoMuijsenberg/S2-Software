using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePooleNationaleVlag
{
    public class Flag
    {
        private string[] stones = new string[10];
        private Random rnd = new Random();

        public Flag()
        {
            for (int i = 0; i < 10; i++)
            {
                int random = rnd.Next(0, 2);

                switch (random)
                {
                    case 0:
                        stones[i] = "red";
                        break;
                    case 1:
                        stones[i] = "white";
                        break;
                }
            }

        }

        public string[] Stones
        {
            get => stones;
        }

        public void SortFlag()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                int whiteIndex = 0;
                int redIndex = 0;
                string temp = "";

                if (stones[i] == "red")
                {
                    redIndex = i;
                    temp = stones[redIndex];
                    for (int j = stones.Length - 1; j >= 0; j--)
                    {
                        if (stones[j] == "white")
                        {
                            whiteIndex = j;
                        }
                    }

                    stones[redIndex] = stones[whiteIndex];
                    stones[whiteIndex] = temp;
                }
            }
        }
    }
}
