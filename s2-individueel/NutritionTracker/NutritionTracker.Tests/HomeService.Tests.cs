using System.Collections.Generic;
using System.Threading.Tasks;
using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Implementation;
using Xunit;
using Moq;

namespace NutritionTracker.Tests;

public class HomeService_Tests
{
    private List<SchemeModel> schemes;
    
    public HomeService_Tests()
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
            }
        };
    }

    [Fact]
    public async void GetSingleScheme_ReturnsScheme()
    {
        //Arrange
        var home = new Mock<IHome>();
        home
            .Setup(m => m.GetSchemesByUserAndDay(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(Task.FromResult(schemes[0]));
        
        var homeService = new HomeService(home.Object);
        
        //Act
        var result = await homeService.GetSingleScheme("userId");

        //Assert
        Assert.Equal(result.result.Name, schemes[0].Name);

    }
}