using Microsoft.Maui.Controls;
using OutdoorShareMauiApp.Pages;

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

            //Routing.RegisterRoute(nameof(LoginPage), typeof(Pages.LoginPage));


            this.Navigating += OnShellNavigating;

            Shell.SetTabBarTitleColor(this, Color.FromArgb("#6366F1"));
            Shell.SetTabBarUnselectedColor(this, Colors.Black);

        }

        private async void OnShellNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Simule la vérification d'une connexion utilisateur
            bool isUserLoggedIn = Preferences.ContainsKey("user_token");

            // Routes nécessitant une connexion
            var protectedRoutes = new[]
            {
                "FavorisPage",
                "PublishPage",
                "MessagesPage",
                "ProfilePage"
            };

            // Vérifie si la destination est protégée
            if (!isUserLoggedIn && protectedRoutes.Any(p => e.Target.Location.OriginalString.Contains(p)))
            {
                e.Cancel(); // Annule la navigation
                await Shell.Current.GoToAsync("LoginPage");

            }
        }

    }
}
