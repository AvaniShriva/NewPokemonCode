using PokemonApp.Models.NewDB;


namespace PokemonApp.Data
{
    public class Query
    {
        public IQueryable<PokemonModel> GetSuperheroes =>
            new List<PokemonModel>().AsQueryable();
    }
}
