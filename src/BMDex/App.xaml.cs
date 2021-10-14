using BMDex.Views;
using Xamarin.Forms;

namespace BMDex
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
