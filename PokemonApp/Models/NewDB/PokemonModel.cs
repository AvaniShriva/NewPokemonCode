using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models.NewDB
{
    public class PokemonModel
    {
        [Key] 
        public int PokemonId { get; set; }
        public string PokemonName { get; set; }  = string.Empty;
        public string PokemonImgUrl { get; set;} = string.Empty;
    }
}
