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

            this.Navigating += OnShellNavigating;

            Shell.SetTabBarTitleColor(this, Color.FromArgb("#6366F1"));
            Shell.SetTabBarUnselectedColor(this, Colors.Black);

        }

        public bool IsUserLoggedIn { get; set; } = false;

        private async void OnShellNavigating(object sender, ShellNavigatingEventArgs e)
        {
            var protectedRoutes = new[]
            {
            "FavorisPage",
            "PublishPage",
            "MessagesPage",
            "ProfilePage"
        };

            if (!IsUserLoggedIn && protectedRoutes.Any(p => e.Target.Location.OriginalString.Contains(p)))
            {
                e.Cancel();
                await Navigation.PushAsync(new LoginPage());
            }
        }

    }
}
