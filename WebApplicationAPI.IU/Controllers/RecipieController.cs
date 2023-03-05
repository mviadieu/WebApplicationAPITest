using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.IU.Application.DTOs;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPI.IU.Controllers;

[Route("api/v1/[controller]/[action]")]

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
    
    [HttpGet(Name = "GetAllRecipies")]
    public IActionResult GetAllRecipies()
    {
        var mRecipies= this._repository.GetAll();
        var modelResult = mRecipies.Select(item=> new RecipieResumeDTO(){ Name = item.Name, IngredientId = item.IngredientId}).ToList();
        return this.Ok(modelResult);
    }
    
    [HttpGet(Name = "GetOneRecipie")]
    public IActionResult GetOneRecipie([FromQuery] int recipieId)
    {
        var parameter = this.Request.Query["recipieId"]; //  this.Request permet de recupérer les param de la request HTTP. this.Request.Query["recipieId"] renvoie donc le int du param. Pas utile ici. Je laisse la ligne pour le debug
        Console.WriteLine(" ==> GetOnRecipie() Method called. ID send in parameters : " + parameter); 
        var modelResult= this._repository.GetOne(recipieId);
        return this.Ok(modelResult);
    }
    
    [HttpPost(Name = "AddOneRecipie")]
    public IActionResult AddOneRecipie(RecipieDTO dtoItems)
    {
        IActionResult result = this.BadRequest();

        Recipie addRecipied = this._repository.AddOne(new Recipie()
        {
            ImagePath = dtoItems.ImagePath,
            Name = dtoItems.Name
        });
        this._repository.UnitOfWork.SaveChanges();

        if (addRecipied != null)
        {
            dtoItems.Id = addRecipied.Id;
            result = this.Ok(dtoItems);
        }
        return result;
    }

    #endregion
    

    
}

