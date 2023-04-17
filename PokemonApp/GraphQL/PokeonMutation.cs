using GraphQL;
using GraphQL.Types;
using PokemonApp.Models.NewDB;
using PokemonApp.Repository.Interface;

namespace PokemonApp.GraphQL
{
    public class PokemonInput : InputObjectGraphType
    {
        public PokemonInput()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("imageUrl");
        }
    }

    public class PokemonMutation : ObjectGraphType
    {
        public PokemonMutation(IPokemonRepository pokemonRepository)
        {
            // Adding details in Mutation.

            Field<PokemonType>("createpokemon",
                arguments: new QueryArguments { new QueryArgument<PokemonInput> { Name = "pokemon" } },
                resolve: x => pokemonRepository.Add(x.GetArgument<PokemonModel>("pokemon")));

            // Deleting details in Mutation.

            Field<PokemonType>(Name = "deletepokemon",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            resolve: x => pokemonRepository.Delete(x.GetArgument<int>("id")));
        }
    }
}
