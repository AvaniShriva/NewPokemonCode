using Microsoft.AspNetCore.Mvc;
using PokemonApp.Data;
using PokemonApp.Models.NewDB;
using PokemonApp.Repository.Interface;
using static PokemonApp.Helper.Helper;

namespace PokemonApp.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ApplicationdbContext db;
        private readonly ITypetable Idata;

        public TypeController(ApplicationdbContext _db, ITypetable _Idata)
        {
            db =_db;
            Idata =_Idata;

        }
        [HttpGet]
        [Route("GetallIType")]
        public async Task<IActionResult> GetAll()
        {
            ResponseBody res = new ResponseBody();

            try
            {
                var result = await Idata.GetData();
                if (result == null)
                {
                    res.Status=false;
                    res.Data= result;
                    res.Message="Data not Found!";
                    res.StatusCode =  System.Net.HttpStatusCode.NoContent;
                   

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
        [Route("AddType")]
        public async Task<IActionResult> AddType(PokemonTypeModel TypeTables)
        {
            ResponseBody res = new ResponseBody();

            try
            {
                var result = await Idata.AddType(TypeTables);
                res.Status = true;
                res.Data = result;
                res.Message = "Data Found !";
                res.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }
        }

        [HttpDelete]
        [Route("DeleteType")]
        public async Task<IActionResult> DeleteType(int id)
        {
            ResponseBody res = new ResponseBody();

            var result = await Idata.DeleteType(id);

            res.Status = true;
            res.Data = result;
            res.Message = "Data Found !";
            res.StatusCode = System.Net.HttpStatusCode.OK;

            return Ok(result);
        }
        [HttpPut]
        [Route("updateType")]
        public async Task<IActionResult> updateData(PokemonTypeModel TypeTables)
        {
            ResponseBody res = new ResponseBody();
            try
            {
                var result = await Idata.UpdateType(TypeTables);
                if (result == null)
                {
                    res.Status = false;
                    res.Data = result;
                    res.Message = "Data not Found!";
                    res.StatusCode = System.Net.HttpStatusCode.NoContent;
                }
                else
                {
                    res.Status = true;
                    res.Data = result;
                    res.Message = "Data Found !";
                    res.StatusCode = System.Net.HttpStatusCode.OK;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }

        }
        [HttpGet]
        [Route("getTypeById")]
        public async Task<IActionResult> getTypeById(int Id)
        {
            ResponseBody res = new ResponseBody();
            try
            {
                var result = await Idata.GetTypeById(Id);

                if (result == null)
                {
                    res.Status = false;
                    res.Data = result;
                    res.Message = "Data not Found!";
                    res.StatusCode = System.Net.HttpStatusCode.NoContent;
                }
                else
                {
                    res.Status = true;
                    res.Data = result;
                    res.Message = "Data Found !";
                    res.StatusCode = System.Net.HttpStatusCode.OK;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }


        }
    }
}
