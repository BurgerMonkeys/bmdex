using System.Threading.Tasks;
using BMDex.Abstractions;
using Prism.Regions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BMDex.Views
{
    public partial class MainPage
    {
        private IRegionManager _regionManager { get; }

        public MainPage(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            Content = Build();
        }

        private async void TabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            if (sender is TabView tabView)
            {
                var tabViewItem = tabView.TabItems[e.NewPosition];
                await InitializeAsync(tabViewItem).ConfigureAwait(false);
            }
        }

        private async Task InitializeAsync(TabViewItem tabViewItem)
        {
            if (tabViewItem.Content.BindingContext is IInitialize viewModel)
            {
                await viewModel.InitializeAsync().ConfigureAwait(false);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await OnAppearingAsync().ConfigureAwait(false);
        }

        private async Task OnAppearingAsync()
        {
            if (Content is TabView tabView)
            {
                var tabViewItem = tabView.TabItems[0];
                await InitializeAsync(tabViewItem).ConfigureAwait(false);
            }
        }
    }
}
