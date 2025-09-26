using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;

namespace PrimerParcial.Data
{
    public class RecetasDBContext : DbContext
    {
        // Constructor que acepta DbContextOptions para la configuración
        public RecetasDBContext(DbContextOptions<RecetasDBContext> options)
            : base(options)
        {
        }

        // DbSets (colecciones) que representan las tablas de la base de datos
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        // Configuración explícita de las relaciones (opcional, pero recomendable para claridad)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a muchos entre Recipe e Ingredient
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Recipe)           // Un ingrediente pertenece a una receta
                .WithMany(r => r.Ingredients)    // Una receta tiene muchos ingredientes
                .HasForeignKey(i => i.RecipeId)  // Clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina una receta, se eliminan sus ingredientes

            // Relación uno a muchos entre Category y Recipe
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)          // Una receta pertenece a una categoría
                .WithMany(c => c.Recipes)         // Una categoría tiene muchas recetas
                .HasForeignKey(r => r.CategoryId) // Clave foránea
                .OnDelete(DeleteBehavior.Restrict); // No permitir borrar categoría si tiene recetas

            base.OnModelCreating(modelBuilder);
        }
    }
}
