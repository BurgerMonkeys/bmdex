using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace BMDex.Views
{
    public partial class PokemonListPage : ContentView
    {
        View Build() => new StackLayout
        {
            BackgroundColor = Color.Green
        };

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

