using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BMDex.Services;
using PokeApiNet;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BMDex.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly PokemonService _pokemonService;
        public ObservableRangeCollection<Pokemon> Pokemon { get; set; }

        public MainViewModel()
        {
            _pokemonService = new PokemonService();
            Pokemon = new ObservableRangeCollection<Pokemon>();
        }

        public override async Task InitializeAsync()
        {
            var pokemon = await _pokemonService.GetPokemon();

            Pokemon.AddRange(pokemon);
        }
    }
}
