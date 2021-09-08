using System.Collections.Generic;
using System.Threading.Tasks;
using BMDex.Resources;
using BMDex.Models;

namespace BMDex.Services
{
    public interface IAbilityService
    {
        Task<IEnumerable<Ability>> GetAbilityListAsync(int limit = 20, int offset = 0);
    }

    public class AbilityService : IAbilityService
    {
        private readonly IResourceService _resourceService;

        public AbilityService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<IEnumerable<Ability>> GetAbilityListAsync(int limit, int offset)
        {
            var urls = await _resourceService.GetUrlListAsync(Endpoints.Ability, limit, offset);
            var abilityData = await _resourceService.GetDetailListAsync<Ability>(urls);
            return abilityData;
        }
    }
}
