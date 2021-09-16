using BMDex.Services;
using BMDex.ViewModels;
using BMDex.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace BMDex
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IResourceService, ResourceService>();
            containerRegistry.Register<IPokemonService, PokemonService>();
            containerRegistry.Register<IAbilityService, AbilityService>();
            RegisterPages(containerRegistry);
        }

        private void RegisterPages(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterRegionServices();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForRegionNavigation<PokemonListPage, PokemonListViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(nameof(MainPage));
        }
    }
}
