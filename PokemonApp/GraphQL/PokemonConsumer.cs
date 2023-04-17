using GraphQL;
using GraphQL.Types;
using PokemonApp.Models.NewDB;
using PokemonApp.Repository.Interface;

namespace PokemonApp.GraphQL
{
    #region GraphQl pokemon schema

    public class PokemonType : ObjectGraphType<PokemonModel>
    {
        public PokemonType()
        {
            Field(x => x.PokemonId);
            Field(x => x.PokemonName);
            Field(x => x.PokemonImgUrl);
        }
    }
    /// <summary>
    ///  Getting all the details from Pokemon in Consumers.
    /// </summary>
    public class PokemonQuery : ObjectGraphType
    {
        public PokemonQuery(IPokemonRepository pokemonRepository)
        {
            //ResponseBody response = new ResponseBody();
            try
            {
                Field<ListGraphType<PokemonType>>(Name = "pokemons", resolve: x => pokemonRepository.GetAll());
                Field<PokemonType>(Name = "pokemon",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            resolve: x => pokemonRepository.GetAll().FirstOrDefault(p => p.PokemonId == x.GetArgument<int>("id")));
            }
            catch (Exception ex)
            {
                //response.Message = ex.Message.ToString();
                //response.Status = false;
                //response.StatusCode = HttpStatusCode.BadRequest;
                //return response;
                throw;
            }
        }
    }

    public class PokemonSchema : Schema
    {
        public PokemonSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<PokemonQuery>();
            Mutation = serviceProvider.GetRequiredService<PokemonMutation>();
        }
    }

    #endregion
}
