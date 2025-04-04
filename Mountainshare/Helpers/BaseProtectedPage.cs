using Microsoft.Maui.Controls;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorShareMauiApp.Helpers
{
    public abstract class BaseProtectedPage : ContentPage
    {
        protected bool IsUserLoggedIn { get; }

        private readonly string[] protectedRoutes = new[]
        {
            "FavorisPage",
            "PublishPage",
            "MessagesPage",
            "ProfilePage"
        };

        protected BaseProtectedPage()
        {
            Shell.SetNavBarIsVisible(this, false);
        }

        protected async void NavigateToLoginPage()
        {
            await Navigation.PushAsync(new LoginPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigateToLoginPage();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
