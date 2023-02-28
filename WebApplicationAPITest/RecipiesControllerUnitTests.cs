using WebApplicationAPI.IU.Controllers;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplicationAPI.IU.Application.DTOs;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPITest;

public class RecipiesControllerUnitTests
{

    #region Public methods

    [Fact]
    public void ShouldAddOneRecipie()
    {
        
    }
    
    [Fact]
    public void ShouldReturnListOfRecipies()
    {
        var expetedListToReturn = new List<Recipie>()
        {
            new Recipie() {Ingredient = new Ingredient()},
            new Recipie() {Ingredient = new Ingredient()}
        };
        
        // ARRANGE 
        var repositoryMock = new Mock<IRecipiesRepository>(); // MOCK _ ON SIMULE LA CREATION D'UN OBJET
        repositoryMock.Setup(item => item.GetAll()).Returns(expetedListToReturn); 
        var controller = new RecipieController(null, repositoryMock.Object);

        // ACT 
        var result = controller.GetRecipiesActionResult();
        
        //ASSERT
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        
        OkObjectResult okResult = result as OkObjectResult;
        
        Assert.NotNull(okResult.Value);
        Assert.IsType<List<RecipieResumeDTO>>(okResult.Value);
        
        List<RecipieResumeDTO> list = okResult.Value as List<RecipieResumeDTO>;
        Assert.True(list.Count == expetedListToReturn.Count);
        
    }
    
    #endregion

}