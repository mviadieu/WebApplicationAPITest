using Microsoft.VisualBasic.CompilerServices;
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
    /// <summary>
    /// Add one picture in DB
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Picture AddOnePicture(string Url, string fileName);
    
    
    
    
    /// <summary>
    /// TO DO 
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="objectId"></param>
    /// <param name="Url"></param>
    /// <returns></returns>
   //  Picture AddOnePicture( ObjectType objectType, int objectId, string Url); // TODO A deporter dans un repo spécifique
    
}