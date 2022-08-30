namespace SimpleAlgoritme;

public class Product
{
    private string _name;
    private double _price;

    public Product(string name, double price)
    {
        _name = name;
        _price = price;
    }

    public string Name
    {
        get => _name;
    }
    
    public double Price
    {
        get => _price;
    }
}