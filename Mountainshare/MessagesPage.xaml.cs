using Microsoft.Maui.Controls;

namespace OutdoorShareMauiApp.Pages
{
    public partial class MessagesPage : ContentPage
    {
        public MessagesPage()
        {
            InitializeComponent();
        }

        private async void OnMessageTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrivateMessagePage());
        }
    }
}