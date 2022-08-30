using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Implementation;
using Xunit;
using Moq;

namespace NutritionTracker.Tests;

public class ExerciseServiceTests
{
    private List<ExcersiseModel> excersises;
    
    public ExerciseServiceTests()
    {
        excersises = new List<ExcersiseModel>
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
            },
            new()
            {
                Id = 1,
                Name = "Tricep extentions",
                SchemeId = 0,
                DisplayOrder = 2,
                Sets = new List<SetModel>
                {
                    new()
                    {
                        Id = 0,
                        Reps = 10,
                        Weight = 10,
                        ExceriseId = 1,
                        DisplayOrder = 1
                    }
                }
            }
        };
    }

    [Fact]
    public async void CreateExercise_CorrectDetails_ReturnsTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Create(It.IsAny<ExcersiseModel>()))
            .Returns(Task.FromResult(excersises[0]));
        
        var exerciseService = new ExcersiseService(crud.Object, Mock.Of<ISet>());
        
        //Act
        var result = await exerciseService.CreateExcersise(excersises[0]);

        //Assert
        Assert.True(result.success);
    }
    
    [Fact]
    public async void CreateExercise_IncorrectDetails_ReturnsFalse()
    {
        //Arrange
        excersises[0].Name = "";
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Create(It.IsAny<ExcersiseModel>()))
            .Returns(Task.FromResult(excersises[0]));
        
        var exerciseService = new ExcersiseService(crud.Object, Mock.Of<ISet>());
        
        //Act
        var result = await exerciseService.CreateExcersise(excersises[0]);

        //Assert
        Assert.False(result.success);
    }
    
    [Fact]
    public async void GetExercise_ReturnsExerciseWithSet()
    {
        //Arrange
        excersises[0].Name = "";
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Read<ExcersiseModel>(It.IsAny<int>()))
            .ReturnsAsync(excersises[0]);

        var set = new Mock<ISet>();
        set
            .Setup(m => m.GetSetByExcersiseId(It.IsAny<int>()))
            .ReturnsAsync(excersises[0].Sets.ToList());
        
        var exerciseService = new ExcersiseService(crud.Object, set.Object);
        
        //Act
        var result = await exerciseService.GetExcersise(0);

        //Assert
        Assert.Equal(result.result.Name, excersises[0].Name);
    }
    
    [Fact]
    public async void UpdateExercise_CorrectDetails_ReturnsTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<ExcersiseModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(excersises[0]));
        
        var exerciseService = new ExcersiseService(crud.Object, Mock.Of<ISet>());
        
        //Act
        var result = await exerciseService.UpdateExcersise(excersises[0]);

        //Assert
        Assert.True(result.success);
    }
    
    [Fact]
    public async void UpdateExercise_IncorrectDetails_ReturnsFalse()
    {
        //Arrange
        excersises[0].Name = "";
        
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Update(It.IsAny<ExcersiseModel>(), It.IsAny<int>()))
            .Returns(Task.FromResult(excersises[0]));
        
        var exerciseService = new ExcersiseService(crud.Object, Mock.Of<ISet>());
        
        //Act
        var result = await exerciseService.UpdateExcersise(excersises[0]);

        //Assert
        Assert.False(result.success);
    }
    
    [Fact]
    public async void DeleteExercise_ReturnsTrue()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<ExcersiseModel>(It.IsAny<int>()))
            .Returns(Task.FromResult(true));
        
        var exerciseService = new ExcersiseService(crud.Object, Mock.Of<ISet>());
        
        //Act
        var result = await exerciseService.DeleteExcersise(0);

        //Assert
        Assert.True(result.success);
    }
    
    [Fact]
    public async void DeleteExercise_ReturnsFalse()
    {
        //Arrange
        var crud = new Mock<ICrud>();
        crud
            .Setup(m => m.Delete<ExcersiseModel>(It.IsAny<int>()))
            .Returns(Task.FromResult(false));
        
        var exerciseService = new ExcersiseService(crud.Object, Mock.Of<ISet>());
        
        //Act
        var result = await exerciseService.DeleteExcersise(0);

        //Assert
        Assert.False(result.success);
    }
}