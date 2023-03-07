using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebApplicationAPICore.Recipies.Infrastructure.Datas;

public class RecipieContextFactory : IDesignTimeDbContextFactory<RecipiesContext>
{
    #region public methods
    
    public Datas.RecipiesContext CreateDbContext(string[] args)
    {
        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(),"Configuration","appSettings.json"));
        IConfigurationRoot configurationRoot = configurationBuilder.Build();
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseSqlServer(configurationRoot
            .GetConnectionString("master"));
        RecipiesContext context = new RecipiesContext(builder.Options);
        return context;
    }

    #endregion
}
