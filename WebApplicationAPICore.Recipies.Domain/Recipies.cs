namespace WebApplicationAPICore.Recipies.Domain;


public class  Recipie
{

    #region Properties

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string ImagePath { get; set; } = string.Empty;
    public int IngredientId { get; set; }
    public virtual Ingredient Ingredient { get; set; }

    #endregion
}