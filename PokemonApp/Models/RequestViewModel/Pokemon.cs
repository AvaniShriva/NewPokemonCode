namespace PokemonApp.Models.Request
{
    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int PokemonTypeId { get; set; }
    }
}
