using Domain.Recipes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    internal class DirectionConfiguration : IEntityTypeConfiguration<Direction>
    {
        public void Configure(EntityTypeBuilder<Direction> builder)
        {
            builder.ToTable("Directions", "Recipe");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("DirectionId");

            builder.Property(x => x.Id).HasConversion(
                directionId => directionId.Value,
                value => new DirectionId(value));

            builder.HasOne<Recipe>()
                .WithMany()
                .HasForeignKey(x => x.RecipeId)
                .IsRequired();
        }
    }
}
