using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Core.Framework;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPICore.Recipies.Infrastructure.Repositories;

public class DefaultRecipieRepository : IRecipiesRepository // Implementation de l'interface
{
    #region fields

    private readonly RecipiesContext _context = null;

    #endregion

    #region contructor

    public DefaultRecipieRepository(RecipiesContext recipiesContext)
    {
        this._context = recipiesContext;
    }

    #endregion

    #region methods

    public ICollection<Recipie> GetAll()
    {
        return this._context.Recipies.Include(item => item.Ingredient).ToList();
    }
    public Recipie GetOne(int recipieId)
    {
        return this._context.Recipies.Include(item => item.Ingredient).Where(w => w.Id == recipieId).FirstOrDefault();
    }
    public Recipie AddOne(Recipie item)
    {
        return this._context.Recipies.Add(item).Entity;
    }
    
    public Picture AddOnePicture(string url, string fileName)
    {
        return this._context.Pictures.Add(new Picture()
        {
            Id = new int(),
            Url = url,
            FileName = fileName,
        }).Entity;
    }


    #endregion

    #region properties

    public IUnitOfWork UnitOfWork => this._context;

    #endregion
}
