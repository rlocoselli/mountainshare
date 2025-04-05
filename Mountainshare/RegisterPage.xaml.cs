using OutdoorShareMauiApp.Services;

namespace OutdoorShareMauiApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private bool isPasswordHidden = true;
    private bool isConfirmPasswordHidden = true;

    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        isPasswordHidden = !isPasswordHidden;
        PasswordEntry.IsPassword = isPasswordHidden;

        var imageButton = sender as ImageButton;
        imageButton.Source = isPasswordHidden ? "eye_icon.png" : "eye_off_icon.png";
    }

    private void OnToggleConfirmPasswordVisibility(object sender, EventArgs e)
    {
        isConfirmPasswordHidden = !isConfirmPasswordHidden;
        ConfirmPasswordEntry.IsPassword = isConfirmPasswordHidden;

        var imageButton = sender as ImageButton;
        imageButton.Source = isConfirmPasswordHidden ? "eye_icon.png" : "eye_off_icon.png";
    }

    private bool IsPasswordSecure(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        if (password.Length < 8)
            return false;

        bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsLower(c)) hasLower = true;
            else if (char.IsDigit(c)) hasDigit = true;
            else hasSpecial = true;
        }

        return hasUpper && hasLower && hasDigit && hasSpecial;
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
            return;
        }

        if (!IsPasswordSecure(password))
        {
            await DisplayAlert("Mot de passe non sécurisé",
                "Le mot de passe doit contenir au moins :\n- 8 caractères\n- 1 majuscule\n- 1 minuscule\n- 1 chiffre\n- 1 caractère spécial",
                "OK");
            return;
        }

        var apiService = new ApiService();
        string result = await apiService.RegisterUser(email, password, email);

        if (result.Contains("User created successfully"))
        {
            await DisplayAlert("Succès", "Inscription réussie", "OK");
            await Navigation.PushAsync(new LoginPage());
        }
        else
        {
            await DisplayAlert("Erreur", result, "OK");
        }
    }

    private async void OnRegLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}