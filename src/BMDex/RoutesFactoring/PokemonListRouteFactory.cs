using BMDex.Services;
using BMDex.ViewModels;
using BMDex.Views;
using Xamarin.Forms;

namespace BMDex.RoutesFactoring
{
	sealed class PokemonListPageRouteFactory : RouteFactory
	{
		public override Element GetOrCreate()
		{
			var pokemonService = DependencyService.Get<IPokemonService>();
			var page = new PokemonListPage
			{
				BindingContext = new PokemonListViewModel(pokemonService)
			};
			return page;
		}
	}
}
