using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMDex.Models;
using BMDex.Resources;
//using PokeApiNet;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace BMDex.Services
{
    public interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetPokemonListAsync(int limit = 20, int offset = 0);
        public Task<Pokemon> GetPokemonAsync(int id);
    }

    public class PokemonService : IPokemonService
    {

        public PokemonService()
        {
        }
        
        public async Task<IEnumerable<Pokemon>> GetPokemonListAsync(int limit, int offset)
        {
            var request = await Resources.Constants.BaseAddress
                .AppendPathSegment("pokemon")
                .SetQueryParam("limit", limit)
                .SetQueryParam("offset", offset)
                .GetAsync();

            var jsonData = await request.GetStringAsync();

            var pokemonData = JsonConvert.DeserializeObject<ResourceResponse<Pokemon>>(jsonData);

            var names = pokemonData.Results.Select(t => t.Name);
            // var content = await _pokeApiClient.GetNamedResourcePageAsync<Pokemon>(limit, offset);
            // var pokemonData = await _pokeApiClient.GetResourceAsync(content.Results);
            //
            return null;//pokemonData;
        }

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            return null;
            // if (id <= 0) return null;
            // try
            // {
            //     // var pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(id);
            //     // return pokemon;                
            // }
            // catch (System.Exception ex)
            // {
            //     System.Console.WriteLine(ex.Message);
            //     return null;
            // }
        }
    }
}
