// See https://aka.ms/new-console-template for more information

using SimpleAlgoritme;


List<Product> products = new List<Product>();

//Add products
products.Add(new Product("product1", 10));
products.Add(new Product("product2", 3));
products.Add(new Product("product3", 5));
products.Add(new Product("product4", 1));


//Create order
Order order = new Order(products);

//Show all products: 
foreach (var product in products)
{
    Console.WriteLine(product.Name + ": " + product.Price);
}
Console.WriteLine("\n");

/*Console.WriteLine("Maximum price = " + order.GiveMaximumPrice());
Console.WriteLine("Average price = " + order.GiveAveragePrice());

Console.WriteLine("All items above certain price:");

foreach (var product in order.GetAllProducts(50))
{
    Console.WriteLine(product.Name);
}*/

order.SortProductsByPrice();