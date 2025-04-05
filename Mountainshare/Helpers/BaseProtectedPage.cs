
using Microsoft.Maui.Controls;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace OutdoorShareMauiApp.Helpers
{
    public abstract class BaseProtectedPage : ContentPage
    {
        protected bool IsUserLoggedIn => Preferences.ContainsKey("AuthToken");

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

            if (!IsUserLoggedIn)
            {
                NavigateToLoginPage();
            }
        }
    }
}
