using System;
using System.Threading.Tasks;
using BMDex.Models;
using BMDex.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BMDex.ViewModels
{
    public class PokemonListViewModel : BaseViewModel
    {
        readonly IPokemonService _pokemonService;
        public ObservableRangeCollection<Pokemon> Pokemon { get; set; }

        public PokemonListViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            Pokemon = new ObservableRangeCollection<Pokemon>();
        }

        public override async Task InitializeAsync()
        {
            var pokemon = await _pokemonService.GetPokemonListAsync();

            Pokemon.AddRange(pokemon);
        }
    }
}
