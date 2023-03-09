using System.Text.Json.Serialization;

namespace WebApplicationAPICore.Recipies.Domain;

public class Picture //  est un value object
{
    #region Properties

    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    
    [JsonIgnore] 
    public List<Recipie> Recipies { get; set; } = new List<Recipie>();
    #endregion
}