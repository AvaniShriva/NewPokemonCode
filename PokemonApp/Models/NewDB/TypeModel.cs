using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models.NewDB
{
    public class TypeModel
    {
        [Key] 
        public int TypeModelId { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
