namespace Circustrein;

public class Wagon
{
    private List<Animal> Animals { get; } = new();

    public void AddAnimal(Animal animal)
    {
        bool willFit = CheckIfAnimalFits(animal);

        if (willFit)
        {
            Animals.Add(animal);
        }
    }

    public int GetPoints()
    {
        int points = 0;

        foreach (Animal animal in Animals)
        {
            points += (int)animal.Size;
        }

        return points;
    }

    public bool CheckIfAnimalFits(Animal animal)
    {
        if (Animals.Count == 0)
        {
            return true;
        }

        if (animal.Food == Food.Meat) //Hij is planten eter
        {
            if (animal.AnimalPoints() == 5) //Groote vlees eter
            {
                return false;
            }

            if (animal.AnimalPoints() == 3) //medium vlees eter
            {
                foreach (var wagonAnimal in Animals)
                {
                    return (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Big) && (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Medium);
                }
            }
            else //Kleine vlees eter
            {
                //Mag geen grote vlees eter of medium vlees eter in zitten
                foreach (var wagonAnimal in Animals)
                {
                    return (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Big) && (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Medium) && (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Small);
                }
            }
        }
        else //Hij is dus plant eter
        {
            if (animal.AnimalPoints() == 5) //Big plant eater
            {
                foreach (var wagonAnimal in Animals)
                {
                    return wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Big;
                }
            }
            else if (animal.AnimalPoints() == 3) //Medium plant eater
            {
                foreach (var wagonAnimal in Animals)
                {
                    return (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Big) && (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Medium);
                }
            }
            else //Small plant eater
            {
                foreach (var wagonAnimal in Animals)
                {
                    return (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Big) && (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Medium) && (wagonAnimal.Food != Food.Meat || wagonAnimal.Size != Size.Small);
                }

            }
        }
        return false;
    }
}