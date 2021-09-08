using System.Linq;
using System.Threading.Tasks;
using AutoBogus;
using BMDex.Models;
using BMDex.Resources;
using BMDex.Services;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace BMDex.Tests.Services
{
    public class AbilityServiceTest
    {
        IResourceService _resourceService;
        IAbilityService _abilityService;

        public AbilityServiceTest()
        {
            _resourceService = A.Fake<IResourceService>();
            _abilityService = new AbilityService(_resourceService);
        }

        [Theory]
        [InlineData(20, 0, 20)]
        [InlineData(100, 300, 27)]
        [InlineData(100, 400, 0)]
        public async Task TestGetAbilities(int limit, int offset, int expectedResult)
        {
            var fakeURLResult = AutoFaker.Generate<string>(expectedResult);
            var fakeAbilityResult = AutoFaker.Generate<Ability>(expectedResult);

            A.CallTo(() => _resourceService.GetUrlListAsync(Endpoints.Ability, limit, offset))
                .Returns(fakeURLResult);
            A.CallTo(() => _resourceService.GetDetailListAsync<Ability>(fakeURLResult))
                .Returns(fakeAbilityResult);

            var abilities = await _abilityService.GetAbilityListAsync(limit, offset);
            abilities.Count().Should().Be(expectedResult);
        }
    }
}
