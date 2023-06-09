﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonApp.Data;

#nullable disable

namespace PokemonApp.Migrations
{
    [DbContext(typeof(ApplicationdbContext))]
    partial class ApplicationdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonApp.Models.NewDB.PokemonModel", b =>
                {
                    b.Property<int>("PokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokemonId"));

                    b.Property<string>("PokemonImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PokemonId");

                    b.ToTable("PokemonModels");
                });

            modelBuilder.Entity("PokemonApp.Models.NewDB.PokemonTypeModel", b =>
                {
                    b.Property<int>("PokemonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokemonTypeId"));

                    b.Property<int>("PokemonModelPokemonId")
                        .HasColumnType("int");

                    b.Property<int>("TypeModelId")
                        .HasColumnType("int");

                    b.HasKey("PokemonTypeId");

                    b.HasIndex("PokemonModelPokemonId");

                    b.HasIndex("TypeModelId");

                    b.ToTable("PokemonTypeModels");
                });

            modelBuilder.Entity("PokemonApp.Models.NewDB.TypeModel", b =>
                {
                    b.Property<int>("TypeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeModelId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeModelId");

                    b.ToTable("TypeModels");

                    b.HasData(
                        new
                        {
                            TypeModelId = 1,
                            TypeName = "Fire"
                        },
                        new
                        {
                            TypeModelId = 2,
                            TypeName = "Water"
                        },
                        new
                        {
                            TypeModelId = 3,
                            TypeName = "Fire"
                        });
                });

            modelBuilder.Entity("PokemonApp.Models.NewDB.PokemonTypeModel", b =>
                {
                    b.HasOne("PokemonApp.Models.NewDB.PokemonModel", "PokemonModel")
                        .WithMany()
                        .HasForeignKey("PokemonModelPokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonApp.Models.NewDB.TypeModel", "TypeModel")
                        .WithMany()
                        .HasForeignKey("TypeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokemonModel");

                    b.Navigation("TypeModel");
                });
#pragma warning restore 612, 618
        }
    }
}
