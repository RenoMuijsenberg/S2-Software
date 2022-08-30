using System.Collections.Generic;
using System.Threading.Tasks;
using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Implementation;
using Xunit;
using Moq;

namespace NutritionTracker.Tests;

public class ProductServiceTests
{
    private List<ProductModel> products;
    public ProductServiceTests()
    {
        products = new List<ProductModel>()
        {
            new()
            {
                Id = 1,
                Name = "Worstenbroodje",
                Protein = 0,
                Calorie = 0,
                Carb = 0,
                Fat = 0,
                Salt = 0,
                Sugar = 0
            },
            new()
            {
                Id = 2,
                Name = "",
                Protein = 0,
                Calorie = 0,
                Carb = 0,
                Fat = 0,
                Salt = 0,
                Sugar = 0
            },
        };
    }
    
    [Fact]
    public async void AddSingleProduct_ProductCreated_ReturnsTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Create(It.IsAny<ProductModel>()))
            .Returns(Task.FromResult(products[0]));
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.AddSingelProduct(products[0], 10);

        //Assert
        Assert.True(createdProduct.success);
    }
    
    [Fact]
    public async void AddSingleProduct_ProductNotCreated_ReturnsFalse()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Create(It.IsAny<ProductModel>()))
            .Returns(Task.FromResult(products[0]));
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.AddSingelProduct(new ProductModel(), 10);

        //Assert
        Assert.False(createdProduct.success);
    }
    
    [Fact]
    public async void GetAllProcts_ReturnListWithProduct()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.ReadAll<ProductModel>())
            .Returns(Task.FromResult(products));
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.GetAllProducts();

        //Assert
        Assert.Equal(createdProduct.result.Count, products.Count);
    }
    
    [Fact]
    public async void GetSingleProduct_ReturnSingleProduct()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Read<ProductModel>(It.IsAny<int>()))
            .Returns(Task.FromResult(products[0]));
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.GetSingleProduct(0);

        //Assert
        Assert.Equal(createdProduct.result.Name, products[0].Name);
    }
    
    [Fact]
    public async void UpdateProduct_CorrectDetails_ReturnTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<ProductModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(products[0]));
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.UpdateSingleProduct(products[0], 1);

        //Assert
        Assert.Equal(createdProduct.result.Name, products[0].Name);
    }
    
    [Fact]
    public async void UpdateProduct_IncorrectDetails_ReturnFalse()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<ProductModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(products[1]));
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.UpdateSingleProduct(products[1], 1);

        //Assert
        Assert.False(createdProduct.success);
    }
    
    [Fact]
    public async void DeleteProduct_ReturnTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<ProductModel>(It.IsAny<int>()))
            .ReturnsAsync(true);
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.DeleteProduct(1);

        //Assert
        Assert.True(createdProduct.success);
    }
    
    [Fact]
    public async void DeleteProduct_ReturnFalse()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<ProductModel>(It.IsAny<int>()))
            .ReturnsAsync(false);
        
        var productService = new ProductService(crud.Object);
        
        //Act
        var createdProduct = await productService.DeleteProduct(1);

        //Assert
        Assert.False(createdProduct.success);
    }
}