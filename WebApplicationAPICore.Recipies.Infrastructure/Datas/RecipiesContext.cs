using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplicationAPI.Core.Framework;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas.TypeConfiguration;

namespace WebApplicationAPICore.Recipies.Infrastructure.Datas;

public class RecipiesContext : DbContext, IUnitOfWork // On implémente le IUnitOfWork dans le context. (là où se trouve le save changes)
{
    
    public RecipiesContext(DbContextOptions<RecipiesContext> options) : base(options)
    {

    }

    public RecipiesContext() : base()
    {
        
    }
    
    #region internal methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("master");
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RecipieEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientEntityTypeConfiguration());
    }

    #endregion

    #region Properties

    public DbSet<Recipie> Recipies { get; set; } = null !;
    public DbSet<Ingredient> Ingredients { get; set; } = null !;

    #endregion
}