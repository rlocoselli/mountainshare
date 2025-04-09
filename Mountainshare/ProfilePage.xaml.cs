
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using OutdoorShareMauiApp.Helpers;

namespace OutdoorShareMauiApp.Pages
{
    public partial class ProfilePage : BaseProtectedPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            // Load user profile on page load
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            // Retrieve username from session
            string username = Preferences.Get("Username", "Utilisateur");

            // Display the username on the profile page
            name.Text = $"{username}";
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilPage());
        }

        private async void OnChangePassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {

            Services.ApiService apiService = new Services.ApiService();
            apiService.ClearSession();


            Application.Current.MainPage = new AppShell();

        }
    }
}
