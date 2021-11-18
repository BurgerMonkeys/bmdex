using BMDex.RoutesFactoring;
using BMDex.Views;
using Xamarin.Forms;

namespace BMDex
{
	sealed partial class AppShell
	{
		void BuildShell()
		{
			var pokemonListPage = new ShellContent
			{
				Content = new PokemonListPage()
			};
			var trainerPage = new ShellContent
			{
				Content = new TrainerPage()
			};

			//Adicionado a página no ShellContent
			var shellSection = new ShellSection();
			shellSection.Title = "Dex";
			shellSection.Items.Add(pokemonListPage);
			var shellSection2 = new ShellSection();
			shellSection2.Title = "Treinador";
			shellSection2.Items.Add(trainerPage);

			//Adicionando o shellContent dentro do TabBar
			var item = new TabBar();
			item.Items.Add(shellSection);
			item.Items.Add(shellSection2);

			//Adicionando toda a estrutura anterior ao Shell
			Items.Add(item);
		}

		void RegisterRoute()
		{
			Routing.RegisterRoute("pokemonListPage", new PokemonListPageRouteFactory());
		}
	}
}
