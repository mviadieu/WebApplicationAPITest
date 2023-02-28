using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.IU.Application.DTOs;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPI.IU.Controllers;

[Route("[controller]")]

[ApiController]
public class RecipieController : ControllerBase
{
    
    #region constructors
    
    private readonly IRecipiesRepository _repository = null;
    private readonly RecipiesContext _context = null;

    public RecipieController(RecipiesContext context, IRecipiesRepository repository)
    {
        this._context = context;
        this._repository = repository;
    }
    
    #endregion
    
    #region public methods

    [HttpGet(Name = "GetRecipiesActionResult")]
    public IActionResult GetRecipiesActionResult()
    {
        var mRecipies= this._repository.GetAll();
        var modelResult = mRecipies.Select(item=> new RecipieResumeDTO(){ Name = item.Name, IngredientId = item.IngredientId}).ToList();
        return this.Ok(modelResult);
    }

    #endregion
    

    
}

