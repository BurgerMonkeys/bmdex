using System.Net.Http;
using System.Threading.Tasks;
using AutoBogus;
using BMDex.Models;
using BMDex.Resources;
using BMDex.Services;
using Flurl.Http.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BMDex.Tests.Services
{
    public class ResourceServiceTest
    {
        private ResourceService _resourceService;
        public ResourceServiceTest()
        {
            _resourceService = new ResourceService();
        }

        [Fact]
        public async Task GetUrlListAsyncTest()
        {
            var fakeURLResult = AutoFaker.Generate<ResourceResponse>(3);

            using var httpTest = new HttpTest();

            httpTest
                .ForCallsTo($"{Constants.BaseAddress}/{Endpoints.Pokemon}")
                .WithVerb(HttpMethod.Get)
                .WithQueryParam("limit", 100)
                .WithQueryParam("offset", 0)
                .RespondWithJson(fakeURLResult, 200);

            var result = await _resourceService.GetUrlListAsync(Endpoints.Pokemon, 100, 0);
        }
    }
}
