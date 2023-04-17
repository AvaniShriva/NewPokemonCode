using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models.NewDB;
using PokemonApp.Repository.Interface;
using static PokemonApp.Helper.Helper;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemon;
        // private readonly PokemonConsumer _consumer;
        public PokemonController(IPokemonRepository pokemon)//, PokemonConsumer consumer)
        {
            _pokemon = pokemon;
            //_consumer = consumer;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var owners = await _consumer.GetAllOwners();
        //    return Ok(owners);
        //}

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            ResponseBody res = new ResponseBody();

            try
            {
                var result = _pokemon.GetAll();
                if (result == null)
                {
                    res.Status=false;
                    res.Message="Data not Found!";
                    res.StatusCode =  System.Net.HttpStatusCode.NoContent;
                    res.Data = result;
                    return Ok(res);
                }
                else
                {
                    res.Status=true;
                    res.Data= result;
                    res.Message="Data Found !";
                    res.StatusCode =  System.Net.HttpStatusCode.OK;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(PokemonModel PokemonTables)
        {
            ResponseBody res = new ResponseBody();
            try
            {
                var result = _pokemon.Add(PokemonTables);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _pokemon.Delete(id);
            return Ok(result);
        }
    }
}
