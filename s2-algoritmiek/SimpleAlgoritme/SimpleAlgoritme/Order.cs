using System.Xml.Serialization;

namespace SimpleAlgoritme;

public class Order
{
    private List<Product> _products;

    public Order(List<Product> products)
    {
        _products = products;
    }
        
    public double GiveMaximumPrice()
    {
        double maxPrice = 0;
        
        foreach (var product in _products)
        {
            if (product.Price > maxPrice)
            {
                maxPrice = product.Price;
            }
        }

        return maxPrice;
    }
    
    public double GiveAveragePrice()
    {
        int count = 0;
        double avgPrice = 0;
        
        foreach (var product in _products)
        {
            count += 1;
            avgPrice += product.Price;
        }

        avgPrice = avgPrice / count;

        return avgPrice;
    }

    public List<Product> GetAllProducts(double minPrice)
    {
        List<Product> allProductsAboveMin = new List<Product>();

        foreach (var product in _products)
        {
            if (product.Price > minPrice)
            {
                allProductsAboveMin.Add(product);
            }
        }

        return allProductsAboveMin;
    }
    
    public List<Product> SortProductsByPrice()
    {
        //Maak nieuwe lijst die net zo groot is als vorige lijst
        List<Product> sortedList = new List<Product>(_products.Count);

        //Loop over alle producten in huidige lijst heen (4x)
        for (int i = 0; i < _products.Count; i++)
        {
            //Onthoud huidige product
            Product product = _products[i];
            //Onthoud huidge index van loop
            var currentIndex = i;

            //Kijk of huidige index grote is als 0 en check of vorige getal in gesorteerde lijst groter is als de huidige product
            while (currentIndex > 0 && sortedList[currentIndex - 1].Price > product.Price)
            {
                //Verlaag de huidige index
                currentIndex--;
            }

            //Voeg to product toe aan nieuwe index op juiste plek
            sortedList.Insert(currentIndex, product);
        }

        return sortedList;
    }
}