using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPI.IU.Controllers;

[Route("[controller]")]

[ApiController]
public class RecipieController : ControllerBase
{
    private readonly RecipiesContext _context = null;

    public RecipieController(RecipiesContext context)
    {
        this._context = context;
    }
    #region public methods

    // [HttpGet(Name = "GetRecipies")]
    // public IEnumerable<Recipie> GetRecipies()
    // {
    //     return Enumerable.Range(1, 10).Select(item => new Recipie() {Id = item, Name = "Delicious snaks "+ item.ToString()} );
    // }
    
    [HttpGet(Name = "GetRecipiesActionResult")]
    public IActionResult GetRecipiesActionResult()
    {
        var model = this._context.Recipies.Select(s=>s.Name).ToList();
        return this.Ok(model);
    }

    #endregion
    

    
}

