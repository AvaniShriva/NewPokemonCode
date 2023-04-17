using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Models.DBModels
{
    public class PokemonsType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }=string.Empty;
        //[ForeignKey("PokemonType")]
        //public int PokemonTypeId { get; set; }
        //public ICollection<PokemonType> PokemonTypes { get; set; }
    }
}
