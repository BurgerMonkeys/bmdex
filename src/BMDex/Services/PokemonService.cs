using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMDex.Models;
using BMDex.Resources;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace BMDex.Services
{
    public interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetPokemonListAsync(int limit = 20, int offset = 0);
    }

    public class PokemonService : IPokemonService
    {
        private readonly IResourceService _resourceService;

        public PokemonService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonListAsync(int limit, int offset)
        {
            var urls = await _resourceService.GetUrlListAsync(Endpoints.Pokemon, limit, offset);
            var pokemon = await _resourceService.GetDetailListAsync<Pokemon>(urls);
            return pokemon;
        }
    }
}
