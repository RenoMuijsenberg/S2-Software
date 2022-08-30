using Xunit;
using SimpleAlgoritme;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAlgoritmeTest
{
    public class ProductTest
    {
        Product product;
        public ProductTest()
        {
            product = new Product("Test Product", 20);
        }

        [Fact]
        public void Get_Product_Name()
        {
            //Arrange
            string productName = product.Name;

            //Act

            //Assert
            Assert.NotNull(productName);
            Assert.Equal(productName, product.Name);
        }

        [Fact]
        public void Get_Product_Price()
        {
            //Arrange
            double productPrice = product.Price;

            //Act

            //Assert
            Assert.Equal(productPrice, product.Price);
        }
    }
}