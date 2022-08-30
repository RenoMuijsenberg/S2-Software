namespace Circustrein
{
    public enum Food
    {
        Meat,
        Plant
    }

    public enum Size
    {
        Small = 1,
        Medium = 3,
        Big = 5
    }

    public class Animal
    {
        public Food Food { get; }
        public Size Size { get; }

        public Animal(Food food, Size size)
        {
            Food = food;
            Size = size;
        }

        public int AnimalPoints()
        {
            return (int)Size;
        }
    }
}
