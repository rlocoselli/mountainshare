using Microsoft.Maui.Controls;
using OutdoorShareMauiApp.Pages;
using OutdoorShareMauiApp;

namespace OutdoorShareMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(Pages.HomePage));
            Routing.RegisterRoute(nameof(FavorisPage), typeof(Pages.FavorisPage));
            Routing.RegisterRoute(nameof(PublishPage), typeof(Pages.PublishPage));
            Routing.RegisterRoute(nameof(MessagesPage), typeof(Pages.MessagesPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(Pages.ProfilePage));

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            Shell.SetTabBarTitleColor(this, Color.FromArgb("#6366F1"));
            Shell.SetTabBarUnselectedColor(this, Colors.Black);
        }
    }
}
