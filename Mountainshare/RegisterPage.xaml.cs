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


    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Erreur", "Veuillez remplir les deux champs de mot de passe.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
            return;
        }

        if (!IsPasswordSecure(password))
        {
            await DisplayAlert("Mot de passe non s�curis�",
                "Le mot de passe doit contenir au moins :\n- 8 caract�res\n- 1 majuscule\n- 1 minuscule\n- 1 chiffre\n- 1 caract�re sp�cial",
                "OK");
            return;
        }


        await DisplayAlert("Succ�s", "Inscription r�ussie (logique � compl�ter).", "OK");


    }


    private async void OnRegLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}