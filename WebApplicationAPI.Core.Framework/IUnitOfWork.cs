using System.Runtime.CompilerServices;

namespace WebApplicationAPI.Core.Framework;

public interface IUnitOfWork 
{
    int SaveChanges();
}