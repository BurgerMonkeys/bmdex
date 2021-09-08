using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace BMDex.Views
{
    public partial class MainPage : ContentPage
    {
        View Build() => new StackLayout
        {
            Children =
            {
                GetHeader(),
                GetList()
            }
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
        
        Frame GetHeader()
        {
            return new BlueFrame
            {
                Content = new Label
                {
                    Text = "This is BMDex!",
                    TextColor = Color.White,
                    HorizontalTextAlignment = TextAlignment.Center
                }.FontSize(Device.GetNamedSize(NamedSize.Title, typeof(Label)))
            };
        }
    }

    public class BlueFrame : Frame
    {
        public BlueFrame()
        {
            BackgroundColor = Color.FromHex("#2196F3");
            Padding = new Thickness(24);
        }
    }
}
