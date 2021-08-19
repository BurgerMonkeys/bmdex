using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BMDex.Models;
using BMDex.Resources;
using Type = BMDex.Models.Type;

namespace BMDex.Services
{
    public interface ITypeService
    {
        Task<IEnumerable<Type>> GeTypeListAsync(int limit = 20, int offset = 0);
    }

    public class TypeService: ITypeService
    {
        private readonly IResourceService _resourceService;

        public TypeService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<IEnumerable<Type>> GeTypeListAsync(int limit = 20, int offset = 0)
        {
            var urls = await _resourceService.GetUrlListAsync(Endpoints.Type, limit, offset);
            var typeData = await _resourceService.GetDetailListAsync<Type>(urls);
            return typeData;
        }
    }
}
