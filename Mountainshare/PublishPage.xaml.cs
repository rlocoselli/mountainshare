using System;
using System.Collections.ObjectModel;
using System.Linq;
using OutdoorShareMauiApp.Helpers;
using Microsoft.Maui.Controls;
using System.Net.Http.Headers;
//using Microsoft.Maui.Essentials;

namespace OutdoorShareMauiApp.Pages
{
    public partial class PublishPage : BaseProtectedPage
    {
        private ObservableCollection<PhotoItem> Photos { get; set; } = new();

        public async Task<string> PublishPhotosAsync(List<string> photoPaths)
        {
            var client = new HttpClient();
            string token = Preferences.Get("auth_token", "");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var form = new MultipartFormDataContent();

            foreach (var path in photoPaths)
            {
                var fileBytes = File.ReadAllBytes(path);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                form.Add(fileContent, "photos", Path.GetFileName(path));
            }

            var response = await client.PostAsync("https://tonapi.com/api/photos/publish", form);

            if (response.IsSuccessStatusCode)
            {
                return "ok";
            }

            return $"error: {response.StatusCode}";
        }

        public PublishPage()
        {
            InitializeComponent();

            Photos.Add(new PhotoItem { IsAddButton = true });

            ImageCollectionView.ItemsSource = Photos;
        }

        private async void OnAddImageClicked(object sender, EventArgs e)
        {
            if (Photos.Count(p => !p.IsAddButton) >= 4)
                return;

            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Choisissez une photo"
                });

                if (result != null)
                {

                    var addItem = Photos.FirstOrDefault(p => p.IsAddButton);
                    if (addItem != null)
                    {
                        addItem.ImageSource = result.FullPath;
                        addItem.IsAddButton = false;
                    }


                    if (Photos.Count < 4)
                    {
                        Photos.Add(new PhotoItem { IsAddButton = true });
                    }


                    ImageCollectionView.ItemsSource = null;
                    ImageCollectionView.ItemsSource = Photos;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.Message, "OK");
            }
        }


    }

    public class PhotoItem
    {
        public string ImageSource { get; set; } = "image_placeholder.png";
        public bool IsAddButton { get; set; } = false;
    }
}
