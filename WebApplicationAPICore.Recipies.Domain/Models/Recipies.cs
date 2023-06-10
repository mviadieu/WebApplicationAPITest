namespace WebApplicationAPICore.Recipies.Domain;


public class  Recipie
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int IngredientId { get; set; }
    public virtual Ingredient Ingredient { get; set; }
    
    public int? PictureId { get; set; }
    public virtual Picture Picture { get; set; }

    #endregion
}