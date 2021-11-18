using System.Threading.Tasks;
using BMDex.Abstractions;
using BMDex.Services;
using BMDex.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;

namespace BMDex.Views
{
    public partial class PokemonListPage
    {
        public PokemonListPage()
        {
            Content = Build();
            Title = "Pokemon";

            BindingContext = new PokemonListViewModel(new PokemonService(new ResourceService()));
        }
        
        private async Task OnAppearingAsync()
        {
            if (BindingContext is IInitialize viewModel)
            {
                await viewModel.InitializeAsync().ConfigureAwait(false);
            }
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await OnAppearingAsync().ConfigureAwait(false);
        }
    }
}