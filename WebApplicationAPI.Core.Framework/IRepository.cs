namespace WebApplicationAPI.Core.Framework;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}