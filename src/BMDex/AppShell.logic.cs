using BMDex.RoutesFactoring;
using BMDex.Views;
using Xamarin.Forms;

namespace BMDex
{
	sealed partial class AppShell
	{
		void BuildShell()
		{
			var content = new ShellContent
			{
				Content = new MainPage()
			};

			//Adicionado a página no ShellContent
			var shellSection = new ShellSection();
			shellSection.Items.Add(content);

			//Adicionando o shellContent dentro do TabBar
			var item = new TabBar();
			item.Items.Add(shellSection);

			//Adicionando toda a estrutura anterior ao Shell
			Items.Add(item);
		}

		void RegisterRoute()
		{
			Routing.RegisterRoute("pokemonListPage", new PokemonListPageRouteFactory());
		}
	}
}
