using Xamarin.Forms;

namespace BMDex
{
	sealed partial class AppShell : Shell
	{
		public AppShell()
		{
			RegisterRoute();
			BuildShell();
		}
	}
}
