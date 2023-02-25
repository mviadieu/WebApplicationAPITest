namespace WebApplicationAPICore.Recipies.Domain;


public class  Recipie
{

    #region Properties

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }

    #endregion
}