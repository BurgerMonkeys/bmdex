using System.Linq;
using AutoBogus;
using BMDex.Models;
using BMDex.Resources;
using BMDex.Services;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace BMDex.Tests.Services
{
    public class PokemonServiceTest
    {
        IResourceService _resourceService;
        IPokemonService _pokemonService;

        public PokemonServiceTest()
        {
            _resourceService = A.Fake<IResourceService>();
            _pokemonService = new PokemonService(_resourceService);
        }

        [Theory]
        [InlineData(20, 0, 20)]
        [InlineData(50, 0, 50)]
        [InlineData(50, 5, 50)]
        [InlineData(0, 0, 20)]
        public async void TestGetPokemon(int limit, int offset, int expectedResult)
        {
            var fakeURLResult = AutoFaker.Generate<string>(expectedResult);
            var fakePokemonResult = AutoFaker.Generate<Pokemon>(expectedResult);

            A.CallTo(() => _resourceService.GetUrlListAsync(Endpoints.Pokemon, limit, offset))
                .Returns(fakeURLResult);

            A.CallTo(() => _resourceService.GetDetailListAsync<Pokemon>(fakeURLResult))
                .Returns(fakePokemonResult);

            var result = await _pokemonService.GetPokemonListAsync(limit, offset);
            result.Count().Should().Be(expectedResult);
        }
    }
}
