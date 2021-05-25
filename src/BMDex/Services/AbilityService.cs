using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiNet;

namespace BMDex.Services
{
    public interface IAbilityService
    {
        Task<List<Ability>> GetAbilities(int limit, int offset);
        Task<Ability> GetAbilityById(int id);
    }

    public class AbilityService : IAbilityService
    {
        readonly PokeApiClient _pokeApiClient;

        public AbilityService()
        {
            _pokeApiClient = new PokeApiClient();
        }

        public async Task<List<Ability>> GetAbilities(int limit, int offset)
        {
            var content = await _pokeApiClient.GetNamedResourcePageAsync<Ability>(limit, offset);
            var abilityData = await _pokeApiClient.GetResourceAsync(content.Results);

            return abilityData;
        }

        public async Task<Ability> GetAbilityById(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                var ability = await _pokeApiClient.GetResourceAsync<Ability>(id);
                return ability;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
