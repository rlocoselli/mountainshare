using Microsoft.Maui.Storage;

namespace OutdoorShareMauiApp.Helpers
{
    public static class SessionManager
    {
        private const string TokenKey = "auth_token";

        public static void SaveToken(string token)
        {
            Preferences.Set(TokenKey, token);
        }

        public static string GetToken()
        {
            return Preferences.Get(TokenKey, string.Empty);
        }

        public static void ClearToken()
        {
            Preferences.Remove(TokenKey);
        }

        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(GetToken());
        }
    }
}
