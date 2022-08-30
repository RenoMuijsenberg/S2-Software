namespace ContainerVervoer;

public class Container
{
    public enum ContainerType
    {
        Normal,
        Valuable,
        Cool
    }
    
    public ContainerType Type { get; }
    public int Weight { get; }
    public int XLocation { get; private set; }
    public int YLocation { get; private set; }
    public int ZLocation { get; private set; }
    
    public Container(ContainerType type, int weight)
    {
        Weight = weight;
        Type = type;
    }

    public void SetLocation(int xLoc, int yLoc, int zLoc)
    {
        XLocation = xLoc;
        YLocation = yLoc;
        ZLocation = zLoc;
    }

    public bool CheckWeight()
    {
        return Weight > 4 && Weight < 31;
    }
}