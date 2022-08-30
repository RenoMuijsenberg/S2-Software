using Xunit;
using SimpleAlgoritme;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAlgoritmeTest
{
    public class OrderTest
    {
        Order order;
        List<Product> products = new List<Product>();

        public OrderTest()
        {
            //Arrange
            products.Add(new Product("product1", 10));
            products.Add(new Product("product2", 60));
            products.Add(new Product("product3", 5));
            products.Add(new Product("product4", 1));

            order = new Order(products);
        }

        [Fact]
        public void Create_New_Order_With_Products()
        {
            //Arrange
            Order newOrder = new Order(products);

            //Act

            //Assert
            Assert.NotNull(order);
        }

        [Fact]
        public void Get_Maximum_Price_Of_Products_In_Order()
        {
            //Arrange
            double expected = products.Max(x => x.Price);

            //Act
            double actual = order.GiveMaximumPrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Average_Price_Of_Order()
        {
            //Arrange
            double expected = products.Average(x => x.Price);

            //Act
            double actual = order.GiveAveragePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_All_Items_Above_Certain_Price()
        {
            //Arrange
            int minPrice = 5;
            List<Product> productList = order.GetAllProducts(minPrice);
            bool itemsAboveMin = true;

            //Act
            foreach (var product in productList)
            {
                if (product.Price < minPrice)
                {
                    itemsAboveMin = false;
                    break;
                }
            }

            //Assert
            Assert.True(itemsAboveMin);
        }

        [Fact]
        public void Sort_Products_In_Order_From_Low_To_High()
        {
            //Arrange
            List<Product> sortedList = order.SortProductsByPrice();
            bool sorted = true;

            //Act
            for (int i = 0; i < sortedList.Count; i++)
            {
                if (!(i + 1 >= sortedList.Count))
                {
                    if (!(sortedList[i + 1].Price >= sortedList[i].Price))
                    {
                        sorted = false;
                        break;
                    }
                }
            }

            //Assert
            Assert.True(sorted);
        }
    }
}