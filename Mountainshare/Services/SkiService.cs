using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

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
        public string Image { get; set; }  // Base64 encoded image string
        public ImageSource ImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(Image)) return null;
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(Image);
                    return ImageSource.FromStream(() => new MemoryStream(imageBytes));
                }
                catch
                {
                    return null;
                }
            }
        }
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

        public ImageSource GetImageFromBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return null;
            byte[] imageBytes = Convert.FromBase64String(base64String);
            return ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }
}