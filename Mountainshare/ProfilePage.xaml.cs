using Microsoft.Maui.Controls;
using OutdoorShareMauiApp.Helpers;
using System.Collections.ObjectModel;

namespace OutdoorShareMauiApp.Pages
{
    public partial class ProfilePage : BaseProtectedPage
    {
        public ObservableCollection<string> Images { get; set; }

        public ProfilePage()
        {
            InitializeComponent();

            Images = new ObservableCollection<string>
            {
                @"http://www.meubusao.com/images/ic_launcher2.png",
            };

            BindingContext = Images;
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilPage());
        }

        private async void OnChangePassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage());
        }

    }

}