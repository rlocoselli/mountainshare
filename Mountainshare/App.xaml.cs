using Microsoft.Maui.Controls;

namespace OutdoorShareMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new AppShell();
        }
    }
}
