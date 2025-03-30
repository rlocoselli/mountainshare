namespace OutdoorShareMauiApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private bool isPasswordHidden = true;


    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        isPasswordHidden = !isPasswordHidden;
        PasswordEntry.IsPassword = isPasswordHidden;

        // Optionnel : changer l’icône selon l’état
        var imageButton = sender as ImageButton;
        imageButton.Source = isPasswordHidden ? "eye_icon.png" : "eye_off_icon.png";
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }


}