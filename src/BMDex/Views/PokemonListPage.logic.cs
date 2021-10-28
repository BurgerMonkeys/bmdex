using BMDex.Services;
using BMDex.ViewModels;

namespace BMDex.Views
{
    public partial class PokemonListPage
    {
        public PokemonListPage()
        {
            Content = Build();

            BindingContext = new PokemonListViewModel(new PokemonService(new ResourceService()));

        }
    }
}