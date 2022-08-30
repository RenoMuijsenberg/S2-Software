namespace ContainerVervoer;

public class Dock
{
    public List<Ship> Ships { get; } = new();
    public List<Container> ContainersOnDock { get; } = new();

    
    public void AddShip(int length, int width)
    {
        Ships.Add(new Ship(length, width));
    }

    public void AddContainers(Container.ContainerType type, int weight)
    {
        Container container = new Container(type, weight);
        bool correctWeight = container.CheckWeight();

        if (correctWeight)
        {
            ContainersOnDock.Add(container);
        }
    } 
}

