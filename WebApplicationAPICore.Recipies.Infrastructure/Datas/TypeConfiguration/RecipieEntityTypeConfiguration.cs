using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationAPICore.Recipies.Domain;

namespace WebApplicationAPICore.Recipies.Infrastructure.Datas.TypeConfiguration;

public class RecipieEntityTypeConfiguration : IEntityTypeConfiguration<Recipie>
{
    #region Public methods

    public void Configure(EntityTypeBuilder<Recipie> builder)
    {
        builder.ToTable("Recipie");
        
        builder.HasKey(item => item.Id);
        builder.HasOne(item => item.Ingredient).WithMany(item=>item.Recipies);
    }

    #endregion
}