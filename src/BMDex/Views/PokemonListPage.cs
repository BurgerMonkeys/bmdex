using BurgerMonkeys.Tools;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace BMDex.Views
{
    public partial class PokemonListPage : ContentPage
    {
        View Build() => GetList();

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
            var grid = new Grid();
            grid.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition
                {
                    Width = 112
                },
                new ColumnDefinition
                {
                    Width = GridLength.Auto
                },
                new ColumnDefinition
                {
                    Width = 100
                }
            };
            grid.RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition
                {
                    Height = 32
                },
                new RowDefinition
                {
                    Height = GridLength.Auto
                },
                new RowDefinition
                {
                    Height = 24
                },
                new RowDefinition
                {
                    Height = 4
                }
            };
            
            var label = new Label().Bind(Label.TextProperty, "FormattedName");
            
            grid.Children.Add(label, EGridColumn.Description.ToInt(), EGridRow.Title.ToInt());

            return grid;
        });
    }
    
    enum EGridRow 
    {
        Title = 0,
        Form = 1,
        Type = 2,
        Divider = 3
    }

    enum EGridColumn
    {
        Picture = 0,
        Description = 1,
        Number = 2
    }
}

