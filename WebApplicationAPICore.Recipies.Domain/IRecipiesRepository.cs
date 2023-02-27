namespace WebApplicationAPICore.Recipies.Domain;

public interface IRecipiesRepository
{
    ICollection<Recipie> GetAll();
}