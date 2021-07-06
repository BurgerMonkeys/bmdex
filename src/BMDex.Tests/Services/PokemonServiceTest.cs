using System.Linq;
using BMDex.Services;
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
            _resourceService = new ResourceService();
            _pokemonService = new PokemonService(_resourceService);
        }

        [Theory]
        [InlineData(20, 0, 20)]
        [InlineData(50, 0, 50)]
        [InlineData(50, 5, 50)]
        [InlineData(0, 0, 20)]
        public async void TestGetPokemon(int limit, int offset, int expectedResult)
        {
            var result = await _pokemonService.GetPokemonListAsync(limit, offset);
            result.Count().Should().Be(expectedResult);
        }
    }
}
