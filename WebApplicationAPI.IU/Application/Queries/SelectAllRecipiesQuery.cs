using MediatR;
using WebApplicationAPI.IU.Application.DTOs;

namespace WebApplicationAPI.IU.Application.Queries;

/// <summary>
/// IRequest : Marker interface to represent request with a void response.
/// Query to select all selfies using DTO class
/// </summary>

public class SelectAllRecipiesQuery : IRequest<List<RecipieResumeDTO>>
{
    #region Properties
    
    public int IngredientId { get; set; }
    
    #endregion
}