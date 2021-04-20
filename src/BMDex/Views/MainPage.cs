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
                GetHeader()
            }
        };

        Frame GetHeader()
        {
            return new BlueFrame
            {
                Content = new Label
                {
                    Text = "Welcome to BMDex!",
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
