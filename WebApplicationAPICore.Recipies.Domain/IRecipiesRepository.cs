using WebApplicationAPI.Core.Framework;
namespace WebApplicationAPICore.Recipies.Domain;

public interface IRecipiesRepository :IRepository
{
    ICollection<Recipie> GetAll();
}