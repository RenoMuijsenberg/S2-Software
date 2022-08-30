using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AModelLayer.Models;
using DAL.Functions.Specific;
using DALInterfaces.Interfaces;
using LOGIC.Services.Implementation;
using Xunit;
using Moq;

namespace NutritionTracker.Tests;

public class SetServiceTests
{
    private List<SetModel> sets;
    
    public SetServiceTests()
    {
        sets = new List<SetModel>
        {
            new()
            {
                Id = 0,
                Reps = 10,
                Weight = 10,
                ExceriseId = 0,
                DisplayOrder = 1
            },
            new()
            {
                Id = 0,
                Reps = 10,
                Weight = 10,
                ExceriseId = 1,
                DisplayOrder = 1
            }
        };
    }

    [Fact]
    public async void CreateSet_CorrectDetails_ReturnsTrue()
    {
        var crud = new Mock<ICrud>();
        crud.Setup(m => m.Create(It.IsAny<SetModel>()))
            .Returns(Task.FromResult(sets[0]));

        var setService = new SetService(crud.Object);

        var result = await setService.CreateSet(sets[0], 0);
        
        Assert.True(result.success);
    }
    
    [Fact]
    public async void CreateSet_IncorrectDetails_ReturnsTrue()
    {
        sets[0].Reps = 0;
        var crud = new Mock<ICrud>();
        crud.Setup(m => m.Create(It.IsAny<SetModel>()))
            .Returns(Task.FromResult(sets[0]));

        var setService = new SetService(crud.Object);

        var result = await setService.CreateSet(sets[0], 0);
        
        Assert.False(result.success);
    }

    [Fact]
    public async void GetSet_ReturnsSet()
    {
        var crud = new Mock<ICrud>();
        crud.Setup(m => m.Read<SetModel>(It.IsAny<int>()))
            .Returns(Task.FromResult(sets[0]));

        var setService = new SetService(crud.Object);

        var result = await setService.GetSet(0);
        
        Assert.Equal(result.result.Id, sets[0].Id);
    }
    
    [Fact]
    public async void UpdateSet_CorrectDetails_ReturnsTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<SetModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(sets[0]));
        
        var setService = new SetService(crud.Object);
        
        //Act
        var result = await setService.UpdateSet(sets[0]);

        //Assert
        Assert.True(result.success);
    }
    
    [Fact]
    public async void UpdateSet_IncorrectDetails_ReturnsFalse()
    {
        //Arrange
        sets[0].Reps = 0;
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<SetModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(sets[0]));
        
        var setService = new SetService(crud.Object);
        
        //Act
        var result = await setService.UpdateSet(sets[0]);

        //Assert
        Assert.False(result.success);
    }
    
    [Fact]
    public async void DeleteSet_ReturnsTrue()
    {
        //Arrange
        sets[0].Reps = 0;
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<SetModel>(It.IsAny<int>()))
            .Returns(Task.FromResult(true));
        
        var setService = new SetService(crud.Object);
        
        //Act
        var result = await setService.DeleteSet(0);

        //Assert
        Assert.True(result.success);
    }
    
    [Fact]
    public async void DeleteSet_ReturnsFalse()
    {
        //Arrange
        sets[0].Reps = 0;
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<SetModel>(It.IsAny<int>()))
            .Returns(Task.FromResult(false));
        
        var setService = new SetService(crud.Object);
        
        //Act
        var result = await setService.DeleteSet(0);

        //Assert
        Assert.False(result.success);
    }
}