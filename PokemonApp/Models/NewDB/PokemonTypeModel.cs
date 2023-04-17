using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models.NewDB
{
    public class PokemonTypeModel
    {
        [Key]

        public int PokemonTypeId { get; set; }
        public virtual PokemonModel PokemonModel { get; set; } = new PokemonModel();
        public virtual TypeModel TypeModel { get; set; } = new TypeModel(); 

    }
}
