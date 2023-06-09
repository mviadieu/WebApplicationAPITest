using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.IU.Application.Commands;
using WebApplicationAPI.IU.Application.DTOs;
using WebApplicationAPI.IU.Application.Queries;
using WebApplicationAPI.IU.ExtentionsMethods;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPI.IU.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
[EnableCors(SecurityMethods.DEFAULT_POLICY)] // Choix de la POLICY (voir SecurityMethods.cs)
public class RecipieController : ControllerBase
{
    
    #region Fields
    
    private readonly IRecipiesRepository _repository = null;
    private readonly RecipiesContext _context = null;
    private readonly IWebHostEnvironment _cWebHostEnvironment = null;
    private readonly IMediator _mediator = null;
    
    #endregion
    
    #region Constructor
    public RecipieController(IMediator mediator, RecipiesContext context, IRecipiesRepository repository, IWebHostEnvironment webHostEnvironment)
    {
        this._context = context;
        this._repository = repository;
        this._cWebHostEnvironment = webHostEnvironment;
        this._mediator = mediator;
    }
    
    #endregion
    
    #region public methods
    
    #region public methods using repository

    #region GET
    
    [HttpGet(Name = "GetAllRecipies")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // le authorize va vérifier qu'on a bien le token. sinon on ne peut pas accéder à l'URL. Restriction par connexion
    [EnableCors(SecurityMethods.DEFAULT_POLICY_2)] // Choix de la POLICY (voir SecurityMethods.cs) Le cors valide la requête AJAX ou WebSocket. 
    public IActionResult GetAllRecipies()
    {
        var mRecipies= this._repository.GetAll();
        var modelResult = mRecipies.Select(item=> new RecipieResumeDTO(){ Name = item.Name, IngredientId = item.IngredientId}).ToList();
        return this.Ok(modelResult);
    }
    
    [HttpGet(Name = "GetOneRecipie")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors(SecurityMethods.DEFAULT_POLICY_2)]
    public IActionResult GetOneRecipie([FromQuery] int recipieId)
    {
        var parameter = this.Request.Query["recipieId"]; //  this.Request permet de recupérer les param de la request HTTP. this.Request.Query["recipieId"] renvoie donc le int du param. Pas utile ici. Je laisse la ligne pour le debug
        Console.WriteLine(" ==> GetOnRecipie() Method called. ID send in parameters : " + parameter); 
        var modelResult= this._repository.GetOne(recipieId);
        return this.Ok(modelResult);
    }
    
    #endregion
    
    #region POST
    
    [HttpPost(Name = "AddOneRecipie")]
    public IActionResult AddOneRecipie(RecipieDTO dtoItems)
    {
        IActionResult result = this.BadRequest();

        Recipie addRecipied = this._repository.AddOne(new Recipie()
        {
            ImagePath = dtoItems.ImagePath,
            Name = dtoItems.Name,
            IngredientId = dtoItems.IngredientId
        });
        this._repository.UnitOfWork.SaveChanges();

        if (addRecipied != null)
        {
            dtoItems.Id = addRecipied.Id;
            result = this.Ok(dtoItems);
        }
        return result;
    }
    
    
    [HttpPost(Name = "AddOnePicture")]
    public async Task<IActionResult> AddOnePicture(IFormFile picture)
    {
        string filePath = Path.Combine(this._cWebHostEnvironment.ContentRootPath, "image/recipie");
        
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        filePath = Path.Combine(filePath, picture.FileName);
        
        using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
        await picture.CopyToAsync(stream);

        var itemFile = this._repository.AddOnePicture(filePath, picture.FileName);
        this._repository.UnitOfWork.SaveChanges();
        
        return this.Ok(itemFile);
    }


    #endregion
    
    #endregion

    #region public methods using mediator

    #region GET
    [HttpGet(Name = "GetAllRecipiesUsingMediator")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors(SecurityMethods.DEFAULT_POLICY_2)]
    public IActionResult GetAllRecipiesUsingMediator()
    {
        var modelResult = this._mediator.Send(new SelectAllRecipiesQuery()); // on envoie la demande au Mediator
        return this.Ok(modelResult);
    }
    #endregion

    #region POST
    
    [HttpPost(Name = "AddOneRecipieUsingMediator")]
    public IActionResult AddOneRecipieUsingMediator(RecipieDTO dtoItems)
    {
        IActionResult result = this.BadRequest();
        
        var itemResult = this._mediator.Send(new AddRecipieCommand{ Item = dtoItems }); // on envoie la demande au Mediator
        if (itemResult != null)
            result = this.Ok(itemResult);
        
        return result;
    }

    #endregion
    
    #endregion

    #endregion
}

