using WebApplicationAPI.IU.Controllers;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplicationAPI.Core.Framework;
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
        // ARRANGE
        RecipieDTO recipie = new RecipieDTO();
        var repositoryMock = new Mock<IRecipiesRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        repositoryMock.Setup(s => s.UnitOfWork).Returns(unitOfWork.Object);
        repositoryMock.Setup(s => s.AddOne(It.IsAny<Recipie>())).Returns(new Recipie(){ Id = 4});
        
        //ACT 
        var controller = new RecipieController(null, repositoryMock.Object,null);
        var result = controller.AddOneRecipie(recipie);
        
        // ASSERT
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);

        var AddedRecipie = (result as OkObjectResult).Value as RecipieDTO;
        Assert.NotNull(AddedRecipie);
        Assert.True(AddedRecipie.Id > 0);

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
        var controller = new RecipieController(null, repositoryMock.Object, null);

        // ACT 
        var result = controller.GetAllRecipies();
        
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