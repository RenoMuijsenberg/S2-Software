namespace DeBesteTijdVoorWetenschappers;

public class YearlyAlive
{
    private int _year;
    private int _aliveCount;

    public YearlyAlive(int year, int aliveCount)
    {
        _year = year;
        _aliveCount = aliveCount;
    }

    public int Year
    {
        get => _year; 
        set => _year = value;
    }
    
    public int AliveCount
    {
        get => _aliveCount; 
        set => _aliveCount = value;
    }
}