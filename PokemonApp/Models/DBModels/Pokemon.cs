using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models.DBModels
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        //[ForeignKey("PokemonType")]
        // public int PokemonTypeId { get; set; } = 0;
       // public ICollection<PokemonType> PokemonTypes { get; set; }
    }
}
