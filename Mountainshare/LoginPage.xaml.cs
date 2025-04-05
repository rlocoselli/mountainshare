using OutdoorShareMauiApp.Services;

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


        var imageButton = sender as ImageButton;
        imageButton.Source = isPasswordHidden ? "eye_icon.png" : "eye_off_icon.png";
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Veuillez entrer un nom d'utilisateur et un mot de passe.", "OK");
            return;
        }

        var apiService = new ApiService();
        string result = await apiService.LoginUser(username, password);

        if (result.Contains("successful"))
        {
            Preferences.Set("auth_token", result); // stocker le token
            await DisplayAlert("Succès", "Connexion réussie", "OK");
        }
        else
        {
            await DisplayAlert("Erreur", result, "OK");
        }
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ResetPasswordPage());
    }
}