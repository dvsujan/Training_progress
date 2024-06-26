﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaShopApi.contexts;

#nullable disable

namespace PizzaShopApi.Migrations
{
    [DbContext(typeof(PizzaShopContext))]
    [Migration("20240515152542_inital")]
    partial class inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaShopApi.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaCrust")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.Property<string>("PizzaTopping")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Description = "Cheese and Tomato",
                            Name = "Margherita",
                            PizzaCrust = 0,
                            PizzaSize = 10,
                            PizzaTopping = "[0]",
                            stock = 10
                        },
                        new
                        {
                            Id = 102,
                            Description = "Pepperoni and Cheese",
                            Name = "Pepperoni",
                            PizzaCrust = 1,
                            PizzaSize = 12,
                            PizzaTopping = "[0,1]",
                            stock = 10
                        },
                        new
                        {
                            Id = 103,
                            Description = "Mushroom, Onion, Capsicum, Tomato, Jalapeno",
                            Name = "Vegetarian",
                            PizzaCrust = 0,
                            PizzaSize = 15,
                            PizzaTopping = "[3,4,5,6,7]",
                            stock = 10
                        });
                });

            modelBuilder.Entity("PizzaShopApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
