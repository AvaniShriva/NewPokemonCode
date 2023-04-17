using PokemonApp.Models.NewDB;

namespace PokemonApp.Repository.Interface
{
    public interface ITypetable
    {
        Task<bool> AddType(PokemonTypeModel TypeTables);
        Task<List<PokemonTypeModel>> GetData();
        Task<bool> DeleteType(int id);
        Task<bool> UpdateType(PokemonTypeModel TypeTables);
        Task<PokemonTypeModel> GetTypeById(int Id);
    }
}
