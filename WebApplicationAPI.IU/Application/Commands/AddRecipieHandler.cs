using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.IU.Application.DTOs;
using WebApplicationAPICore.Recipies.Domain;

namespace WebApplicationAPI.IU.Application.Commands;

public class AddRecipieHandler : IRequestHandler<AddRecipieCommand, RecipieDTO>
{
    #region Fields
    
    private readonly IRecipiesRepository _repository = null;
    
    #endregion
    
    #region Constructors
    
    public AddRecipieHandler(IRecipiesRepository repository)
    {
        this._repository = repository;
    }
    #endregion

    #region Public methods

    public Task<RecipieDTO> Handle(AddRecipieCommand request, CancellationToken cancellationToken)
    {
        RecipieDTO result = null;
        Recipie addRecipied = this._repository.AddOne(new Recipie()
        {
            ImagePath = request.Item.ImagePath,
            Name = request.Item.Name,
            IngredientId = request.Item.IngredientId
        });
        this._repository.UnitOfWork.SaveChanges();
        
        if (addRecipied != null)
        {
            request.Item.Id = addRecipied.Id;
            result = request.Item;
        }
        return Task.FromResult(result);
    }

    #endregion
}