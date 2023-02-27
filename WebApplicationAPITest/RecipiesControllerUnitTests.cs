using WebApplicationAPI.IU.Controllers;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPITest;

public class RecipiesControllerUnitTests
{

    #region Public methods
    
    [Fact]
    public void ShouldReturnListOfRecipies()
    {
        // ARRANGE 
        var repositoryMock = new Mock<IRecipiesRepository>();
        repositoryMock.Setup(item => item.GetAll()).Returns(new List<Recipie>()
        {
            new Recipie(),
            new Recipie()
        });
        var controller = new RecipieController(null, repositoryMock.Object);

        // ACT 
        var result = controller.GetRecipiesActionResult();
        
        //ASSERT
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        
        OkObjectResult okResult = result as OkObjectResult;
        Assert.NotNull(okResult.Value);
        
    }
    
    #endregion

}