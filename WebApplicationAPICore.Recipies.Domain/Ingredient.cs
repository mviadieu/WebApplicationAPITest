using System.Text.Json.Serialization;
namespace WebApplicationAPICore.Recipies.Domain;

public class Ingredient
{
    #region Properties

    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    [JsonIgnore] 
    public List<Recipie> Recipies { get; set; } = new List<Recipie>();


    #endregion
}