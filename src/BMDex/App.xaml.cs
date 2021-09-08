using BMDex.Services;
using BMDex.ViewModels;
using BMDex.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace BMDex
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IResourceService, ResourceService>();
            containerRegistry.Register<IPokemonService, PokemonService>();
            containerRegistry.Register<IAbilityService, AbilityService>();
            RegisterPages(containerRegistry);
        }

        private void RegisterPages(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
        }
        protected override void OnInitialized()
        {
            
        }
    }
}
