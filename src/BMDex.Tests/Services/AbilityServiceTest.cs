using System;
using System.Threading.Tasks;
using BMDex.Services;
using FluentAssertions;
using Xunit;

namespace BMDex.Tests.Services
{
    public class AbilityServiceTest
    {
        IAbilityService _abilityService;

        public AbilityServiceTest()
        {
            _abilityService = new AbilityService();
        }

        [Theory]
        [InlineData(20, 0, 20)]
        [InlineData(100, 300, 27)]
        [InlineData(100, 400, 0)]
        [InlineData(100, -10, 0)]
        [InlineData(-11, -10, 0)]
        public async Task GetAbilities(int limit, int offset, int expected)
        {
            var result = await _abilityService.GetAbilities(limit, offset);

            result.Should().NotBeNull();
            result.Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, "stench")]
        [InlineData(100, "stall")]
        [InlineData(253, "perish-body")]
        public async Task GetAbilityByValidId(int id, string expected)
        {
            var result = await _abilityService.GetAbilityById(id);

            result.Should().NotBeNull();
            result.Name.Should().Be(expected);
        }

        [Theory]
        [InlineData("stench", 1)]
        [InlineData("stall", 100)]
        [InlineData("perish-body", 253)]
        public async Task GetAbilityByValidName(string name, int expected)
        {
            var result = await _abilityService.GetAbilityByName(name);

            result.Should().NotBeNull();
            result.Id.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("burgermonkeys")]
        public async Task GetAbilityByInvalidName(string name)
        {
            var result = await _abilityService.GetAbilityByName(name);

            result.Should().BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        public async Task GetAbilityByInvalidId(int id)
        {
            var result = await _abilityService.GetAbilityById(id);
            result.Should().BeNull();
        }
    }
}
