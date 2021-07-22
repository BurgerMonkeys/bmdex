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
    public interface IResourceService
    {
        Task<IEnumerable<string>> GetUrlListAsync(string endpoint, int limit, int offset);
        Task<IEnumerable<T>> GetDetailListAsync<T>(IEnumerable<string> urlList);
    }

    public class ResourceService: IResourceService
    {
        public virtual async Task<IEnumerable<string>> GetUrlListAsync(string endpoint, int limit, int offset)
        {
            var request = await Constants.BaseAddress
                .AppendPathSegment(endpoint)
                .SetQueryParam("limit", limit)
                .SetQueryParam("offset", offset)
                .GetAsync();

            var jsonData = await request.GetStringAsync();
            var pokemonData = JsonConvert.DeserializeObject<ResourceResponse>(jsonData);
            var urls = pokemonData.Results.Select(t => t.Url);

            return urls;
        }

        public async Task<IEnumerable<T>> GetDetailListAsync<T>(IEnumerable<string> urlList)
        {
            List<T> items = new List<T>();
            foreach (var url in urlList)
            {
                var result = await url.GetAsync();
                var json = await result.GetStringAsync();
                var itemDetail = JsonConvert.DeserializeObject<T>(json);
                items.Add(itemDetail);
            }
            return items;
        }
    }
}
