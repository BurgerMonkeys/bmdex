using BurgerMonkeys.Tools;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace BMDex.Views
{
    public partial class PokemonListPage : ContentPage
    {
        View Build() => GetList();

        private CollectionView GetList()
        {
            var collectionView = new CollectionView
            {
                ItemTemplate = GetDataTemplate(),
                Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Color.FromHex("#62ACDD"), 0),
                        new GradientStop(Color.FromHex("#B2FCFC"), 1)
                    }
                }
            };

            collectionView.Bind(ItemsView.ItemsSourceProperty, "Pokemon");

            return collectionView;
        }

        private DataTemplate GetDataTemplate() => new DataTemplate(() =>
        {
            var grid = new Grid
            {
                BackgroundColor = Color.Transparent
            };
            grid.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition
                {
                    Width = 112
                },
                new ColumnDefinition
                {
                    Width = GridLength.Star
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
                    Height = GridLength.Auto
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
            
            var pokemonPicture = new Image
            {
                WidthRequest = 90,
                HeightRequest = 90,
                Margin = new Thickness(11, 5)
            }
            .Bind(Image.SourceProperty, "ImageURL");

            var nameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                Margin = new Thickness(0, 10)
            }
            .Bind(Label.TextProperty, "FormattedName");

            var numberLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.End,
                Margin = new Thickness(16, 10)
            }
            .Bind(Label.TextProperty, "FormattedDexNumber");

            var typeStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var firstTypeLabel = new Label().Bind(Label.TextProperty, "Types[0].Type.FormattedName");

            var secondTypeLabel = new Label().Bind(Label.TextProperty, "Types[1].Type.FormattedName");

            var backgroundShape = new Ellipse
            {
                Fill = Brush.White,
                Stroke = Brush.White,
                Opacity = 0.3,
                WidthRequest = 80,
                HeightRequest = 80,
                Margin = new Thickness(16, 10)
            };

            var dividerShape = new BoxView
            {
                Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Color.FromHex("#00FFFFFF"), 0),
                        new GradientStop(Color.FromHex("#FFFFFFFF"), 0.5f),
                        new GradientStop(Color.FromHex("#00FFFFFF"), 1)
                    }
                }
            };

            grid.Children.Add(backgroundShape, EGridColumn.Picture.ToInt(), EGridRow.Title.ToInt());
            grid.Children.Add(pokemonPicture, EGridColumn.Picture.ToInt(), EGridRow.Title.ToInt());
            Grid.SetRowSpan(backgroundShape, 3);
            Grid.SetRowSpan(pokemonPicture, 3);
            grid.Children.Add(nameLabel, EGridColumn.Description.ToInt(), EGridRow.Title.ToInt());
            grid.Children.Add(numberLabel, EGridColumn.Number.ToInt(), EGridRow.Title.ToInt());
            typeStack.Children.Add(firstTypeLabel);
            typeStack.Children.Add(secondTypeLabel);
            grid.Children.Add(typeStack, EGridColumn.Description.ToInt(), EGridRow.Type.ToInt());
            Grid.SetRowSpan(typeStack, 2);
            grid.Children.Add(dividerShape, EGridColumn.Picture.ToInt(), EGridRow.Divider.ToInt());
            Grid.SetColumnSpan(dividerShape, 3);

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

