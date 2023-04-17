using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Models.NewDB;
using PokemonApp.Repository.Interface;

namespace PokemonApp.Repository.Service
{
    public class TypeTabledata : ITypetable
    {
        private readonly ApplicationdbContext db;

        public TypeTabledata(ApplicationdbContext data)
        {
            db=data;
        }
        public async Task<bool> AddType(PokemonTypeModel TypeTables)
        {
            PokemonTypeModel res = new PokemonTypeModel();
            try
            {
                PokemonTypeModel obj = new PokemonTypeModel();
                obj.PokemonModel = TypeTables.PokemonModel;
                obj.TypeModel = TypeTables.TypeModel;

                await db.PokemonTypeModels.AddAsync(obj);
                int a = await db.SaveChangesAsync();
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteType(int id)
        {
            try
            {
                var obj = await db.PokemonTypeModels.Where(x => x.PokemonTypeId == id).FirstOrDefaultAsync();
                if (obj != null)
                {

                    db.PokemonTypeModels.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PokemonTypeModel> GetTypeById(int Id)
        {
            try
            {
                var obj = await db.PokemonTypeModels.Where(x => x.PokemonTypeId == Id).FirstOrDefaultAsync();
                if (obj != null)
                {
                    return obj;
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<PokemonTypeModel>> GetData()
        {
            try
            {
                var data = await db.PokemonTypeModels.ToListAsync();

                return data;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateType(PokemonTypeModel TypeTables)
        {
            try
            {
                var Data = await db.PokemonTypeModels.Where(x => x.PokemonTypeId == TypeTables.PokemonTypeId).FirstOrDefaultAsync();
                if (Data != null)
                {
                    Data.PokemonModel= TypeTables.PokemonModel;
                    Data.TypeModel = TypeTables.TypeModel;



                    db.Entry(Data).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
