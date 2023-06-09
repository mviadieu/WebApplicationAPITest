using MediatR;
using WebApplicationAPI.IU.Application.DTOs;

namespace WebApplicationAPI.IU.Application.Commands;

/// <summary>
/// Command to add one recipie on Database
/// </summary>
public class AddRecipieCommand: IRequest<RecipieDTO>
{
    #region Properties
    
    public RecipieDTO Item { get; set; }
    
    #endregion
}
