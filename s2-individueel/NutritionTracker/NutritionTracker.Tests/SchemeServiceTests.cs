using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AModelLayer.Models;
using DAL.Functions.Crud;
using DAL.Functions.Specific;
using DALInterfaces.Interfaces;
using LOGIC.Services.Implementation;
using Xunit;
using Moq;

namespace NutritionTracker.Tests;

public class SchemeServiceTests
{
    private List<SchemeModel> schemes;
        
    public SchemeServiceTests()
    {
        schemes = new List<SchemeModel>
        {
            new()
            {
                Id = 0,
                Name = "Chest/triceps",
                UserId = "116413d7-2da0-4fc4-bbf0-987430893aed",
                DayOne = "Monday",
                DayTwo = "Thursday",
                Excersises = new List<ExcersiseModel>
                {
                    new()
                    {
                        Id = 0,
                        Name = "Benchpress",
                        SchemeId = 0,
                        DisplayOrder = 1,
                        Sets = new List<SetModel>
                        {
                            new()
                            {
                                Id = 0,
                                Reps = 10,
                                Weight = 10,
                                ExceriseId = 0,
                                DisplayOrder = 1
                            }
                        }
                    }
                }
            },
            new()
            {
                Id = 1,
                Name = "Back/biceps",
                UserId = "116413d7-2da0-4fc4-bbf0-987430893aed",
                DayOne = "Tuesday",
                DayTwo = "Friday",
                Excersises = new List<ExcersiseModel>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Benchpress",
                        SchemeId = 1,
                        DisplayOrder = 1,
                        Sets = new List<SetModel>
                        {
                            new()
                            {
                                Id = 1,
                                Reps = 10,
                                Weight = 10,
                                ExceriseId = 1,
                                DisplayOrder = 1
                            }
                        }
                    }
                }
            }
        };
    }
    
    [Fact]
    public async void GetSchemeByUserId_ReturnsListOfSchemes()
    {
        //Arrange
        var scheme = new Mock<IScheme>();
        scheme
            .Setup(m => m.GetSchemesByUser(It.IsAny<string>()))
            .ReturnsAsync(schemes);
        
        var schemeService = new SchemeService(new Mock<ICrud>().Object, scheme.Object);
        
        //Act
        var createdProduct = await schemeService.GetSchemesByUserId(string.Empty);

        //Assert
        Assert.Equal(createdProduct.result.Count, schemes.Count);
    }
    
    [Fact]
    public async void GetSchemeById_ReturnsSingleSchemes()
    {
        //Arrange
        var scheme = new Mock<IScheme>();
        scheme
            .Setup(m => m.GetSchemeById(It.IsAny<int>()))
            .ReturnsAsync(schemes[0]);
        
        var schemeService = new SchemeService(new Mock<ICrud>().Object, scheme.Object);
        
        //Act
        var createdProduct = await schemeService.GetSchemeById(0);

        //Assert
        Assert.Equal(createdProduct.result.Name, schemes[0].Name);
    }
    
    [Fact]
    public async void CreateScheme_ReturnsTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Create(It.IsAny<SchemeModel>()))
            .ReturnsAsync(schemes[0]);
        
        var schemeService = new SchemeService(crud.Object, new Mock<IScheme>().Object);
        
        //Act
        var createdProduct = await schemeService.CreateScheme(schemes[0]);

        //Assert
        Assert.True(createdProduct.success);
    }
    
    [Fact]
    public async void CreateScheme_ReturnsFalse()
    {
        //Arrange
        schemes[0].Name = "";
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Create(It.IsAny<SchemeModel>()))
            .ReturnsAsync(schemes[0]);
        
        var schemeService = new SchemeService(crud.Object, new Mock<IScheme>().Object);
        
        //Act
        var createdProduct = await schemeService.CreateScheme(schemes[0]);

        //Assert
        Assert.False(createdProduct.success);
    }
    
    [Fact]
    public async void UpdateScheme_CorrectDetails_ReturnTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<SchemeModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(schemes[0]));
        
        var schemeService = new SchemeService(crud.Object, new Mock<IScheme>().Object);
        
        //Act
        var createdProduct = await schemeService.UpdateScheme(schemes[0]);

        //Assert
        Assert.Equal(createdProduct.result.Name, schemes[0].Name);
    }
    
        
    [Fact]
    public async void UpdateScheme_IncorrectDetails_ReturnFalse()
    {
        //Arrange
        schemes[0].Name = "";
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<SchemeModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(schemes[0]));
        
        var schemeService = new SchemeService(crud.Object, new Mock<IScheme>().Object);
        
        //Act
        var createdProduct = await schemeService.UpdateScheme(schemes[0]);

        //Assert
        Assert.False(createdProduct.success);
    }
    
    [Fact]
    public async void DeleteProduct_ReturnTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<SchemeModel>(It.IsAny<int>()))
            .ReturnsAsync(true);
        
        var schemeService = new SchemeService(crud.Object, new Mock<IScheme>().Object);
        
        //Act
        var createdProduct = await schemeService.DeleteScheme(1);

        //Assert
        Assert.True(createdProduct.success);
    }
    
    [Fact]
    public async void DeleteProduct_ReturnFalse()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<SchemeModel>(It.IsAny<int>()))
            .ReturnsAsync(false);
        
        var schemeService = new SchemeService(crud.Object, new Mock<IScheme>().Object);
        
        //Act
        var createdProduct = await schemeService.DeleteScheme(1);

        //Assert
        Assert.False(createdProduct.success);
    }
}