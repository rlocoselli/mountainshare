using Newtonsoft.Json;
using System.Text;

namespace OutdoorShareMauiApp.Services
{
    public class SkiMaterial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public string MaterialType { get; set; }
        public DateTime PostedAt { get; set; }
    }

    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string baseUrl = "https://skistation-11242cad9673.herokuapp.com/api/";

        public async Task<List<SkiMaterial>> GetSkiMaterialsAsync()
        {
            try
            {
                var response = await client.GetStringAsync(baseUrl + "skimaterial");
                return JsonConvert.DeserializeObject<List<SkiMaterial>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
        }

        public async Task<string> RegisterUser(string username, string password, string email)
        {
            try
            {
                var requestData = new
                {
                    username = username,
                    password = password,
                    email = email
                };

                var jsonContent = new StringContent(
                    JsonConvert.SerializeObject(requestData),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(baseUrl + "userview/register/", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return "User created successfully: " + result;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return $"Error: {response.StatusCode} - {error}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

        private void SaveSession(string token)
        {
            Preferences.Set("AuthToken", token);
            Preferences.Set("IsLogged", true);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
        }

        public void ClearSession()
        {
            Preferences.Remove("AuthToken");
            Preferences.Remove("IsLogged");
            client.DefaultRequestHeaders.Authorization = null;
        }

        public static bool IsUserLogged()
        {
            return Preferences.Get("IsLogged", false);
        }

        public string GetAuthToken()
        {
            return Preferences.Get("AuthToken", string.Empty);
        }

        public async Task<string> LoginUser(string username, string password)
        {
            try
            {
                var requestData = new
                {
                    username = username,
                    password = password
                };

                var jsonContent = new StringContent(
                    JsonConvert.SerializeObject(requestData),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(baseUrl + "login/", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

                    if (loginResponse.ContainsKey("token"))
                    {
                        string token = loginResponse["token"];
                        SaveSession(token);
                        Preferences.Set("auth_token", token); // stocker le token
                        return "Login successful";
                    }
                    return "Error: Token not found in response";
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return $"Error: {response.StatusCode} - {error}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }


    }
}