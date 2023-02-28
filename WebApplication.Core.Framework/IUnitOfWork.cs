namespace WebApplication.Core.Framework;

public interface IUnitOfWork
{
    int SaveChanges();
}