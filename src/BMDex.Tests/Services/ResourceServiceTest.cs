using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoBogus;
using BMDex.Models;
using BMDex.Resources;
using BMDex.Services;
using Bogus;
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

        [Theory]
        [InlineData(Endpoints.Pokemon)]
        [InlineData(Endpoints.Ability)]
        [InlineData(Endpoints.Type)]
        public async Task GetUrlListAsyncShouldReturnProperUrls(string endpoint)
        {
            var fakeURLResult = AutoFaker.Generate<ResourceResponse>();
            var expectedResult = fakeURLResult.Results.Select(r => r.Url);
            
            using var httpTest = new HttpTest();

            httpTest
                .ForCallsTo($"{Constants.BaseAddress}{endpoint}")
                .WithVerb(HttpMethod.Get)
                .WithQueryParam("limit",100)
                .WithQueryParam("offset", 0)
                .RespondWithJson(fakeURLResult);

            var result = await _resourceService.GetUrlListAsync(endpoint, 100, 0);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetDetailListUrlShouldReturnAPokemonList()
        {
            var faker = new Faker();
            var fakeUrl = faker.Internet.Url();
            var fakeUrlList = new List<string>() { fakeUrl };
            var fakePokemon = AutoFaker.Generate<Pokemon>();
            var fakePokemonList = new List<Pokemon>() { fakePokemon };

            using var httpTest = new HttpTest();

            httpTest.ForCallsTo(fakeUrl)
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(fakePokemon);

            var result = await _resourceService.GetDetailListAsync<Pokemon>(fakeUrlList);
            
            result.Should().BeEquivalentTo(fakePokemonList);
        }
        
        [Fact]
        public async Task GetDetailListUrlShouldReturnAnAbilityList()
        {
            var faker = new Faker();
            var fakeUrl = faker.Internet.Url();
            var fakeUrlList = new List<string>() { fakeUrl };
            var fakeAbility = AutoFaker.Generate<Ability>();
            var fakeAbilityList = new List<Ability>() { fakeAbility };

            using var httpTest = new HttpTest();

            httpTest.ForCallsTo(fakeUrl)
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(fakeAbility);

            var result = await _resourceService.GetDetailListAsync<Ability>(fakeUrlList);
            
            result.Should().BeEquivalentTo(fakeAbilityList);
        }
    }
}