using PokemonApp.Data;
using PokemonApp.Models.NewDB;
using PokemonApp.Repository.Interface;
using System.Net;
using static PokemonApp.Helper.Helper;

namespace PokemonApp.Repository.Service
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationdbContext _dbContext;

        public PokemonRepository(ApplicationdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PokemonModel Add(PokemonModel model)
        {
            ResponseBody<PokemonModel> body = new ResponseBody<PokemonModel>();
            try
            {
                PokemonModel pokemon = new()
                {
                    PokemonName = model.PokemonName,
                    PokemonImgUrl = model.PokemonImgUrl,
                    //PokemonTypes =model.PokemonTypes
                };

                _dbContext.PokemonModels.Add(pokemon);
                _dbContext.SaveChanges();

                body.Message = "Data Added Successfully";
                body.Data = pokemon;
                body.StatusCode =  HttpStatusCode.OK;
                body.Status = true;
                return body.Data;

            }
            catch (Exception ex)
            {

                body.Message = ex.Message.ToString();
                body.StatusCode = HttpStatusCode.BadRequest;
                body.Status = false;
                return body.Data;
            }

        }

        public PokemonModel Delete(int id)
        {
            ResponseBody<PokemonModel> body = new ResponseBody<PokemonModel>();
            try
            {
                var pokemon = _dbContext.PokemonModels.FirstOrDefault(p => p.PokemonId == id);
                if (pokemon != null)
                {

                    _dbContext.Remove(pokemon);
                    _dbContext.SaveChanges();
                }
                body.Message = "Data Deleted Successfully";
                body.Status= true;
                body.StatusCode= HttpStatusCode.OK;
                body.Data = pokemon;

                return body.Data;
            }
            catch (Exception ex)
            {
                body.Message = ex.Message.ToString();
                body.StatusCode = HttpStatusCode.BadRequest;
                body.Status = false;
                return body.Data;
            }
        }


        public List<PokemonModel> GetAll()
        {
            ResponseBody<List<PokemonModel>> body = new ResponseBody<List<PokemonModel>>();
            try
            {
                var pokemons = _dbContext.PokemonModels.ToList();

                body.Message = "Data found Successfully";
                body.Status = true;
                body.StatusCode = HttpStatusCode.OK;
                body.Data = pokemons;

                return body.Data;
            }
            catch (Exception ex)
            {
                body.Message = ex.Message.ToString();
                body.StatusCode = HttpStatusCode.BadRequest;
                body.Status = false;
                return body.Data;
            }
        }
    }
}
