using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiNet;

namespace BMDex.Services
{
    public interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetPokemon();
    }

    public class PokemonService : IPokemonService
    {
        readonly PokeApiClient _pokeApiClient;

        public PokemonService()
        {
            _pokeApiClient = new PokeApiClient();
        }

        public async Task<IEnumerable<Pokemon>> GetPokemon()
        {
            var content = await _pokeApiClient.GetNamedResourcePageAsync<Pokemon>(20, 0);
            var pokemonData = await _pokeApiClient.GetResourceAsync(content.Results);

            return pokemonData;
        }
    }
}
