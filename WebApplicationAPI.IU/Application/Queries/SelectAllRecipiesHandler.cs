using MediatR;
using WebApplicationAPI.IU.Application.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using WebApplicationAPICore.Recipies.Domain;

namespace WebApplicationAPI.IU.Application.Queries;

public class SelectAllRecipiesHandler : IRequestHandler<SelectAllRecipiesQuery, List<DTOs.RecipieResumeDTO>>
{
    
    #region Fields
    private readonly IRecipiesRepository _repository = null;
    #endregion
    
    #region Constructors
    public SelectAllRecipiesHandler(IRecipiesRepository repository)
    {
        this._repository = repository;
    }
    #endregion

    #region Public methods

    public Task<List<RecipieResumeDTO>> Handle(SelectAllRecipiesQuery request, CancellationToken cancellationToken)
    {
        var mRecipies= this._repository.GetAll();
        var modelResult = mRecipies.Select(item=> new RecipieResumeDTO(){ Name = item.Name, IngredientId = item.IngredientId}).ToList();
        return Task.FromResult(modelResult);
    }

    #endregion
}