using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiNet;

namespace BMDex.Services
{
    public interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetPokemon(int limit, int offset);
        public Task<Pokemon> GetPokemon(int id);
    }

    public class PokemonService : IPokemonService
    {
        readonly PokeApiClient _pokeApiClient;

        public PokemonService()
        {
            _pokeApiClient = new PokeApiClient();
        }

        public async Task<IEnumerable<Pokemon>> GetPokemon(int limit = 20, int offset = 0)
        {
            var content = await _pokeApiClient.GetNamedResourcePageAsync<Pokemon>(limit, offset);
            var pokemonData = await _pokeApiClient.GetResourceAsync(content.Results);

            return pokemonData;
        }

        public async Task<Pokemon> GetPokemon(int id)
        {
            if (id <= 0) return null;
            try
            {
                var pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(id);
                return pokemon;                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
