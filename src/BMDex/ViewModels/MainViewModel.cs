using System.Threading.Tasks;
using BMDex.Views;
using Prism.Navigation;
using Prism.Regions;
using Prism.Regions.Navigation;

namespace BMDex.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IRegionManager _regionManager { get; }

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize(INavigationParameters parameters)
        {
            _regionManager.RequestNavigate("DexTab", nameof(PokemonListPage));
        }
    }
}
