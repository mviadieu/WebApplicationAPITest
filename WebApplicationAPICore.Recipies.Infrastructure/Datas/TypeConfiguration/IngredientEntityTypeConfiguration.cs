using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationAPICore.Recipies.Domain;

namespace WebApplicationAPICore.Recipies.Infrastructure.Datas.TypeConfiguration;

public class IngredientEntityTypeConfiguration : IEntityTypeConfiguration<Ingredient>
{
    #region Public methods

    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredient");
    }

    #endregion
}