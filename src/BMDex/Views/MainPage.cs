using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Prism.Regions;
using Region = Prism.Regions.Region;

namespace BMDex.Views
{
    public partial class MainPage : ContentPage
    {
        View Build() => new Grid
        {
            Children =
            {
                GetTabView()
            }
        };

        private TabView GetTabView()
        {
            var tabView = new TabView
            {
                TabStripPlacement = TabStripPlacement.Bottom
            };

            tabView.TabItems.Add(new TabViewItem
            {
                Text = "Dex",
                TextColor = Color.FromHex("#999999"),
                TextColorSelected = Color.FromHex("#FF0000"),
                Content = GetRegion()
            });

            tabView.TabItems.Add(new TabViewItem
            {
                Text = "Treinador",
                TextColor = Color.FromHex("#999999"),
                TextColorSelected = Color.FromHex("#FF0000"),
                Content = new StackLayout
                {
                    BackgroundColor = Color.Red
                }
            });

            tabView.SelectionChanged += TabView_SelectionChanged;

            return tabView;
        }

        private ContentView GetRegion()
        {
            var view = new ContentView();
            //var manager = new RegionManager();
            //var region = new Region();

            view.Invoke(p =>
                _regionManager.RegisterViewWithRegion<PokemonListPage>("DexTab")
            );

            //region.Name = "DexTab";

            return view;
        }

        private CollectionView GetList()
        {
            var collectionView = new CollectionView
            {
                ItemTemplate = GetDataTemplate()
            };

            collectionView.Bind(ItemsView.ItemsSourceProperty, "Pokemon");

            return collectionView;
        }

        private DataTemplate GetDataTemplate() => new DataTemplate(() =>
        {
            var stack = new StackLayout();
            var label = new Label()
                .Bind(Label.TextProperty, "Name");

            stack.Children.Add(label);

            return stack;
        });
    }
}
