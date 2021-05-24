using System;
using System.Linq;
using BMDex.Services;
using FluentAssertions;
using Xunit;

namespace BMDex.Tests.Services
{
    public class PokemonServiceTest
    {
        IPokemonService _pokemonService;

        public PokemonServiceTest()
        {
            _pokemonService = new PokemonService();
        }

        [Theory]
        [InlineData(20, 0, 20)]
        [InlineData(50, 0, 50)]
        [InlineData(50, 5, 50)]
        [InlineData(100, 1100, 18)]
        [InlineData(100, 1118, 0)]
        [InlineData(0, 0, 20)]
        public async void TestGetPokemon(int limit, int offset, int expectedResult)
        {
            var result = await _pokemonService.GetPokemon(limit, offset);
            result.Count().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1, "bulbasaur")]
        [InlineData(658, "greninja")]
        [InlineData(424, "ambipom")]
        public async void TestGetPokemonByValidId(int id, string expectedResult)
        {
            var result = await _pokemonService.GetPokemon(id);
            result.Name.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public async void TestGetPokemonByInvalidId(int id)
        {
            var result = await _pokemonService.GetPokemon(id);
            result.Should().BeNull();
        }
    }
}
