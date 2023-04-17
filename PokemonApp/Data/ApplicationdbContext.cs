using Microsoft.EntityFrameworkCore;
using PokemonApp.Models.NewDB;

namespace PokemonApp.Data
{
    /// <summary>
    /// Seting All the tables in the Database
    /// </summary>
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext()
        {
        }

        public ApplicationdbContext(DbContextOptions options) : base(options)
        {
        }
      
        public DbSet<PokemonModel> PokemonModels { get; set; }
        public DbSet<PokemonTypeModel> PokemonTypeModels { get; set; }
        public DbSet<TypeModel> TypeModels { get; set; }

        /// <summary>
        /// Performed Seeding Operation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeModel>().HasData(

                new TypeModel
                {
                    TypeModelId = 1,
                    TypeName = "Fire",
                },
                new TypeModel
                {
                    TypeModelId = 2,
                    TypeName = "Water",
                },
                new TypeModel
                {
                    TypeModelId = 3,
                    TypeName = "Fire",
                }
            );
        }
    }
}
