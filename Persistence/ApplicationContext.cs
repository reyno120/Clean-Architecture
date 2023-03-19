using Domain.Directions;
using Domain.Recipes;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Direction> Directions { get; set; }
        //public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>()
                .ToTable(
                    "Recipes",
                    "Recipe",
                    builder =>
                    {
                        builder.Property(recipe => recipe.Id).HasColumnName("RecipeId");
                    });

            modelBuilder.Entity<Direction>()
                .ToTable(
                    "Directions",
                    "Recipe",
                    builder =>
                    {
                        builder.Property(direction => direction.Id).HasColumnName("DirectionId");
                    });
        }
    }
}
