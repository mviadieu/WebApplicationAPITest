using WebApplicationAPI.Core.Framework;
namespace WebApplicationAPICore.Recipies.Domain;

/// <summary>
/// Repository to manage recipies
/// </summary>
public interface IRecipiesRepository :IRepository
{
    /// <summary>
    /// Get one recipie
    /// </summary>
    /// <returns></returns>
    Recipie GetOne(int recipieId);
    /// <summary>
    /// Get all recipies
    /// </summary>
    /// <returns></returns>
    ICollection<Recipie> GetAll();
    /// <summary>
    /// Add one in DB
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Recipie AddOne(Recipie recipie);
}