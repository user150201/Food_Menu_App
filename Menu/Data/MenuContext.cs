using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngrediant>().HasKey(di => new
            {
                di.DishId,
                di.IngrediantId
            });

            modelBuilder.Entity<DishIngrediant>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngrediants)
                .HasForeignKey(d => d.DishId);


            modelBuilder.Entity<DishIngrediant>()
                .HasOne(i => i.Ingrediant)
                .WithMany(di => di.DishIngrediants)
                .HasForeignKey(i => i.IngrediantId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margheritta", Price = 7.50, ImageUrl = "https://cdn.shopify.com/s/files/1/0274/9503/9079/files/20220211142754-margherita-9920_5a73220e-4a1a-4d33-b38f-26e98e3cd986.jpg?v=1723650067" });

            modelBuilder.Entity<Ingrediant>().HasData(
                new Ingrediant { Id = 1, Name = "Tomato Sauce" },
                new Ingrediant { Id = 2, Name = "Mozarella" }
                );

            modelBuilder.Entity<DishIngrediant>().HasData(
                new DishIngrediant { DishId = 1, IngrediantId = 1 },
                new DishIngrediant { DishId = 1, IngrediantId = 2 }
                );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }

    public DbSet<Ingrediant> Ingrediants { get; set; }
        public DbSet<DishIngrediant> DishIngrediants { get; set; }
    }
}
