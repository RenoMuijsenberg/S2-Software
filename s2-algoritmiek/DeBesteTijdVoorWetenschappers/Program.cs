using DeBesteTijdVoorWetenschappers;

List<Scientist> scientists = new List<Scientist>();

using(var reader = new StreamReader(@"scientists.csv"))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line.Split(';');
        
        scientists.Add(new Scientist(values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2])));
    }
}

//Eerste minimale en maximale zoeken
//Daarna gaan kijken voor elk jaar hoeveel er leefde
//Dat ergens opslaan
//Kijken waar er het meeste zijn.

int minimum = scientists[0].YearOfBirth;
int maximum = 0;


foreach (var scientist in scientists)
{
    if (scientist.YearOfBirth < minimum)
    {
        minimum = scientist.YearOfBirth;
    }
    
    if (scientist.YearOfDeath > maximum)
    {
        maximum = scientist.YearOfDeath;
    }
}

List<YearlyAlive> yearlyAlive = new List<YearlyAlive>();

for (int i = minimum; i < maximum; i++)
{
    //i is 1452 tot 2004
    int countForYear = 0;
    foreach (var scientist in scientists)
    {
        if (i >= scientist.YearOfBirth && i < scientist.YearOfDeath)
        {
            countForYear += 1;
        }
    }
    yearlyAlive.Add(new YearlyAlive(i, countForYear));
}

int maximumAlive = 0;
int maximumYear = 0;

foreach (var alive in yearlyAlive)
{
    if (alive.AliveCount > maximumAlive)
    {
        maximumYear = alive.Year;
        maximumAlive = alive.AliveCount;
    }
}

Console.WriteLine("Year: " + maximumYear + ", alive: " + maximumAlive);