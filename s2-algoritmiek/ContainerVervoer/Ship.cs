namespace ContainerVervoer;

public class Ship
{
    public int MaxLength { get; }
    public int MaxWidth { get; }
    public int MaxWeight { get; }
    public List<Container> Containers { get; } = new();
    
    private int _left;
    private int _right;
    private int _length;
    private int _height;
    
    public Ship(int xMax, int yMax)
    {
        MaxLength = xMax;
        MaxWidth = yMax;
        MaxWeight = (5 * MaxLength * MaxWidth) * 30;
        InitPlacementVariables();
    }

    private void InitPlacementVariables()
    {
        _left = 1;
        _right = MaxWidth;
        _length = 1;
        _height = 1;
    }

    private bool CheckContainerAmount(int amount)
    {
        bool willFit = amount <= MaxWeight / 30;

        if (!willFit) 
            MessageBox.Show("Containers wont fit on ship!");

        return willFit;
    }

    public void SortContainers(List<Container> containersToSort)
    {
        if (!CheckContainerAmount(containersToSort.Count)) return;

        if (CheckForCoolable(containersToSort))
        {
            ContainerLogic(containersToSort, Container.ContainerType.Cool);
            _left = 1;
            _right = MaxWidth;
            _length = 2;
            _height = 1;
        }
        
        if (CheckForNormal(containersToSort))
            ContainerLogic(containersToSort, Container.ContainerType.Normal);

        _left = 1;
        _right = MaxWidth;
        _length = 1;
        _height = 1;

        if (CheckForValuable(containersToSort))
            ContainerLogic(containersToSort, Container.ContainerType.Valuable);

        if (!CheckLoadPercent()) return;
        if (!CheckWeightMargin()) return;

        MessageBox.Show("Ship ready for take off!");
    }

    private void ContainerLogic(List<Container> containersToSort, Container.ContainerType type)
    {
        List<Container> containers = SplitListToType(containersToSort, type);
        containers = SortContainerOnWeight(containers);
        PlaceContainers(containers, CheckForCoolable(containersToSort));
    }
    
    private void PlaceContainer(Container container, int length, int width, int height) 
    {
        if (CheckStackWeight(_length, _left, container))
        {
            container.SetLocation(length, width, height);
            Containers.Add(container);
        }
    }

    private void PlaceContainers(List<Container> containers, bool wasCoolable)
    {
        for (int i = 0; i < containers.Count(); i++)
        {
            if (i % 2 == 0) // 0 > 2 > 4 > 6 > 8 > 10 etc
            {
                if (containers[i].Type == Container.ContainerType.Valuable)
                    _height = GetStackHeight(_left, _length); //Get highest index on stack +1
                if (CheckStackWeight(_length, _left, containers[i]))
                    PlaceContainer(containers[i], _length, _left, _height);
                else
                    for (int y = _left; y < MaxWidth; y++)
                    {
                        if (CheckStackWeight(_length, y, containers[i]))
                            PlaceContainer(containers[i], _length, y, _height);
                    }
                _left++;
            }
            else // 1 > 3 > 5 > 7 > 9 > 11 etc
            {
                if (containers[i].Type == Container.ContainerType.Valuable)
                    _height = GetStackHeight(_left, _length); //Get highest index on stack +1
                if (CheckStackWeight(_length, _right, containers[i]))
                    PlaceContainer(containers[i], _length, _right, _height);
                else
                    for (int y = _right; y > 0; y--) //Check in rest of row where place
                    {
                        if (CheckStackWeight(_length, y, containers[i]))
                            PlaceContainer(containers[i], _length, y, _height);
                    }
                _right--;
            }
            ResetAfterPlacing(containers[i].Type, wasCoolable);
        }
    }

    private void ResetAfterPlacing(Container.ContainerType type, bool wasCoolable)
    {
        //Move vars to next row or reset
        if (type == Container.ContainerType.Cool)
        {
            ResetAfterCoolable();
        }
        else if (type == Container.ContainerType.Normal)
        {
            ResetAfterNormal(wasCoolable);
        }
        else
        {
            ResetAfterValuable();
        }
    }

    private void ResetAfterCoolable()
    {
        if (_left > _right || _right < _left)
        {
            _height += 1;
            _right = MaxWidth;
            _left = 1;
        }
    }

    private void ResetAfterNormal(bool wasCoolable)
    {
        if (_left > _right || _right < _left)
        {
            if (MaxLength == _length)
            {
                _length = wasCoolable ? 2 : 1;
                _right = MaxWidth;
                _left = 1;
                _height += 1;
            }
            else
            {
                _length += 1;
                _right = MaxWidth;
                _left = 1;
            }
        }
    }

    private void ResetAfterValuable()
    {
        if (_left > _right || _right < _left)
        {
            _length = MaxLength;
            _left = 1;
            _right = MaxWidth;
        }
    }

    private List<Container> SplitListToType(List<Container> containersToSort, Container.ContainerType type)
    {
        List<Container> splitList = new();
        
        for (int i = 0; i < containersToSort.Count(); i++) //Get all coolable containers from list
        {
            if (containersToSort[i].Type == type) //Check index in loop is cool
            {
                splitList.Add(containersToSort[i]); //Add coolable container to new list
            }
        }

        return splitList;
    }

    private List<Container> SortContainerOnWeight(List<Container> containerToSort)
    {
        for (int i = 0; i < containerToSort.Count() - 1; i++)
        {
            for (int j = i + 1; j < containerToSort.Count(); j++)
            {
                if (containerToSort[i].Weight < containerToSort[j].Weight)
                {
                    (containerToSort[i], containerToSort[j]) = (containerToSort[j], containerToSort[i]);
                }
            }
        }

        return containerToSort;
    }

    private bool CheckWeightMargin()
    {
        double halfShip = MaxWidth / (double)2;
        int leftWeight = 0;
        int rightWeight = 0;
        int loadedWeight = 0;

        foreach (var container in Containers)
        {
            loadedWeight += container.Weight;
        }

        if (halfShip % 1 == 0) //Whole number
        {
            for (int i = 1; i <= halfShip; i++)
            {
                foreach (var container in Containers)
                {
                    if (container.YLocation == i)
                    {
                        leftWeight += container.Weight;
                    }
                }
            }

            for (int i = MaxWidth; i > halfShip; i--)
            {
                foreach (var container in Containers)
                {
                    if (container.YLocation == i)
                    {
                        rightWeight += container.Weight;
                    }
                }
            }
        }

        int leftProcent = (leftWeight * 100 / loadedWeight);
        int rightProcent = (rightWeight * 100 / loadedWeight);
        
        bool weightMargin = (leftProcent < 60 || leftProcent > 40 && rightProcent < 60 || rightProcent > 40);

        if (!weightMargin)
        {
            MessageBox.Show("Ship not evenly loaded!");
            Containers.Clear();
        }

        return weightMargin;
    }

    private bool CheckLoadPercent()
    {
        int loadedWeight = 0;

        foreach (var container in Containers)
        {
            loadedWeight += container.Weight;
        }

        bool willFit = (loadedWeight * 100 / MaxWeight) > 50;

        if (!willFit)
        {
            MessageBox.Show("Ship is not loaded enough");
            Containers.Clear();
        }
        
        return willFit;
    }

    private int GetStackHeight(int width, int length)
    {
        int stackHeight = 0;

        foreach (var t in Containers)
        {
            if (t.YLocation == width && t.XLocation == length)
            {
                if (t.ZLocation > stackHeight)
                {
                    stackHeight = t.ZLocation;
                }
            }
        }

        stackHeight += 1;

        return stackHeight;
    }

    private bool CheckForCoolable(List<Container> containersToSort)
    {
        bool check = false;

        foreach (var container in containersToSort)
        {
            if (container.Type == Container.ContainerType.Cool)
            {
                check = true;
                break;
            }
        }

        return check;
    }

    private bool CheckForNormal(List<Container> containersToSort)
    {
        bool check = false;

        foreach (var container in containersToSort)
        {
            if (container.Type == Container.ContainerType.Normal)
            {
                check = true;
                break;
            }
        }

        return check;
    }

    private bool CheckForValuable(List<Container> containersToSort)
    {
        bool check = false;

        foreach (var container in containersToSort)
        {
            if (container.Type == Container.ContainerType.Valuable)
            {
                check = true;
                break;
            }
        }

        return check;
    }

    private bool CheckStackWeight(int xLoc, int yLoc, Container container)
    {
        int stackWeigth = 0;

        foreach (var cont in Containers)
        {
            if (cont.XLocation == xLoc && cont.YLocation == yLoc)
            {
                stackWeigth += cont.Weight;
            }
        }

        if (stackWeigth + container.Weight > 120)
        {
            return false;
        }

        return true;
    }
}

