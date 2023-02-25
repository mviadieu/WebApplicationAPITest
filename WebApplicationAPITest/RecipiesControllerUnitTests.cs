using WebApplicationAPI.IU.Controllers;
using Xunit;
using System;

namespace WebApplicationAPITest;

public class RecipiesControllerUnitTests
{

    #region Public methods
    
    [Fact]
    public void ShouldReturnListOfRecipies()
    {
        // ARRANGE 
        var controller = new RecipieController(context: null);

        // ACT 
        var result = controller.GetRecipiesActionResult();
        
        //ASSERT
        Assert.NotNull(result);
        // Assert.True(result.GetEnumerator().MoveNext());
    }
    
    #endregion

}