using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas.TypeConfiguration;

namespace WebApplicationAPICore.Recipies.Infrastructure.Datas;

public class RecipiesContext : DbContext
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