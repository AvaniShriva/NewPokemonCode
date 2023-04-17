using PokemonApp.Models.NewDB;

namespace PokemonApp.Repository.Interface
{
    public interface IPokemonRepository
    {
        PokemonModel Add(PokemonModel model);
        PokemonModel Delete(int id);
        List<PokemonModel> GetAll();
    }
}
