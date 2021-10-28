using BMDex.Services;
using BMDex.Views;
using Xamarin.Forms;

namespace BMDex
{
    public partial class App
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            RegisterServices();
        }


        void RegisterServices()
		{
            DependencyService.Register<IResourceService, ResourceService>();
            var resourceService = DependencyService.Get<IResourceService>();
            DependencyService.RegisterSingleton<IPokemonService>(new PokemonService(resourceService));
        }
    }
}
