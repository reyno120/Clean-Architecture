using Domain.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Configurations
{
    internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes", "Recipe");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("RecipeId");

            builder.Property(x => x.Id).HasConversion(
                recipeId =>  recipeId.Value,
                value => new RecipeId(value));

            builder.HasMany(x => x.Directions)
                .WithOne()
                .HasForeignKey(o => o.RecipeId);
        }
    }
}
