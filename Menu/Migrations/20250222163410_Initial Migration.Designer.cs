﻿// <auto-generated />
using Menu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Menu.Migrations
{
    [DbContext(typeof(MenuContext))]
    [Migration("20250222163410_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0274/9503/9079/files/20220211142754-margherita-9920_5a73220e-4a1a-4d33-b38f-26e98e3cd986.jpg?v=1723650067",
                            Name = "Margheritta",
                            Price = 7.5
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngrediant", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngrediantId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "IngrediantId");

                    b.ToTable("DishIngrediants");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            IngrediantId = 1
                        },
                        new
                        {
                            DishId = 1,
                            IngrediantId = 2
                        });
                });

            modelBuilder.Entity("Menu.Models.Ingrediant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingrediants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tomato Sauce"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mozarella"
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngrediant", b =>
                {
                    b.HasOne("Menu.Models.Dish", "Dish")
                        .WithMany("DishIngrediants")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menu.Models.Ingrediant", "Ingrediant")
                        .WithMany("DishIngrediants")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingrediant");
                });

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Navigation("DishIngrediants");
                });

            modelBuilder.Entity("Menu.Models.Ingrediant", b =>
                {
                    b.Navigation("DishIngrediants");
                });
#pragma warning restore 612, 618
        }
    }
}
