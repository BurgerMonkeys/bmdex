using System;
using System.Linq;
using System.Threading.Tasks;
using AutoBogus;
using BMDex.Resources;
using BMDex.Services;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using Type = BMDex.Models.Type;

namespace BMDex.Tests.Services
{
    public class TypeServiceTest
    {
        IResourceService _resourceService;
        ITypeService _typeService;

        public TypeServiceTest()
        {
            _resourceService = A.Fake<IResourceService>();
            _typeService = new TypeService(_resourceService);
        }

        [Theory]
        [InlineData(20, 0, 20)]
        public async Task GetTypeListAsyncShouldReturnProperList(int limit, int offset, int expectedResult)
        {
            var fakeURLResult = AutoFaker.Generate<string>(expectedResult);
            var fakeTypeResult = AutoFaker.Generate<Type>(expectedResult);

            A.CallTo(() => _resourceService.GetUrlListAsync(Endpoints.Type, limit, offset))
                .Returns(fakeURLResult);
            A.CallTo(() => _resourceService.GetDetailListAsync<Type>(fakeURLResult))
                .Returns(fakeTypeResult);

            var types = await _typeService.GeTypeListAsync(limit, offset);
            types.Count().Should().Be(expectedResult);
        }
    }
}
