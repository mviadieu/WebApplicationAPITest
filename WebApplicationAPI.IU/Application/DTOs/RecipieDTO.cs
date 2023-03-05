using WebApplicationAPICore.Recipies.Domain;

namespace WebApplicationAPI.IU.Application.DTOs;

public class RecipieDTO
{
    #region Properties
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string ImagePath { get; set; }

    #endregion
}