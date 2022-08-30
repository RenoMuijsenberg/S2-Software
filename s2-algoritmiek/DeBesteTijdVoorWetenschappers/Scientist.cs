namespace DeBesteTijdVoorWetenschappers;

public class Scientist
{
    private string _name;
    private int _birthYear;
    private int _yearOfDeath;
    
    public Scientist(string name, int birthYear, int yearOfDeath)
    {
        _name = name;
        _birthYear = birthYear;
        _yearOfDeath = yearOfDeath;
    }

    public string Name
    {
        get => _name; 
        set => _name = value;
    }
    
    public int YearOfBirth
    {
        get => _birthYear; 
        set => _birthYear = value;
    }
    
    public int YearOfDeath
    {
        get => _yearOfDeath; 
        set => _yearOfDeath = value;
    }
}