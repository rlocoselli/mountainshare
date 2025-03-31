using System;
using Microsoft.Maui.Controls;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace OutdoorShareMauiApp;

public partial class EditProfilPage : ContentPage
{
    public EditProfilPage()
    {
        InitializeComponent();
    }

    private async void OnEditPhotoClicked(object sender, EventArgs e)
    {
        await CrossMedia.Current.Initialize();

        if (!CrossMedia.Current.IsPickPhotoSupported)
        {
            await DisplayAlert("Erreur", "La sélection de photo n'est pas supportée sur cet appareil.", "OK");
            return;
        }

        var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
        {
            PhotoSize = PhotoSize.Medium
        });

        if (file == null)
            return;

        ProfileImage.Source = ImageSource.FromStream(() => file.GetStream());
    }

    private async void OnMessageTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PrivateMessagePage());
    }
}
