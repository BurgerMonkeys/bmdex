using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoBogus;
using BMDex.Models;
using BMDex.Resources;
using BMDex.Services;
using FluentAssertions;
using Flurl.Http.Testing;
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
        public async Task GetUrlListAsyncShouldReturnProperUrls()
        {
            var fakeURLResult = AutoFaker.Generate<ResourceResponse>();
            var expectedResult = fakeURLResult.Results.Select(r => r.Url);
            
            using var httpTest = new HttpTest();

            httpTest
                .ForCallsTo($"{Constants.BaseAddress}{Endpoints.Pokemon}")
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(fakeURLResult);

            var result = await _resourceService.GetUrlListAsync(Endpoints.Pokemon, 100, 0);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}