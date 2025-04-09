using System;
using System.Collections.ObjectModel;
using System.Linq;
using OutdoorShareMauiApp.Helpers;
using OutdoorShareMauiApp.Services;
using Microsoft.Maui.Controls;
//using Microsoft.Maui.Essentials;
using System.Collections.Generic;

namespace OutdoorShareMauiApp.Pages
{
    public partial class PublishPage : BaseProtectedPage
    {
        private ObservableCollection<PhotoItem> Photos { get; set; } = new();

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

                    if (Photos.Count(p => !p.IsAddButton) < 4)
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

        private async void OnAddMaterialClicked(object sender, EventArgs e)
        {
            var title = TitleEntry.Text;
            var description = DescriptionEditor.Text;
            var materialType = CategoryPicker.SelectedItem?.ToString();
            var priceText = PriceEntry.Text;
            decimal.TryParse(priceText, out var price);

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(materialType))
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs obligatoires.", "OK");
                return;
            }

            var userId = Preferences.Get("user_id", 0);

            // 👇 DEBUG : afficher la valeur de user_id
            await DisplayAlert("Debug", $"User ID: {userId}", "OK");

            if (userId == 0)
            {
                await DisplayAlert("Erreur", "Utilisateur non reconnu.", "OK");
                return;
            }

            var imagePaths = Photos
                .Where(p => !p.IsAddButton)
                .Select(p => p.ImageSource)
                .ToList();

            var api = new ApiService();
            var result = await api.AddSkiMaterialAsync(
                title,
                description,
                materialType,
                price,
                imagePaths,
                "Chamonix", // ou depuis un champ plus tard
                null // id de station de ski si disponible
            );

            await DisplayAlert("Résultat", result, "OK");

            if (result.StartsWith("Matériel ajouté"))
            {
                await Navigation.PopAsync();
            }
        }
    }

    public class PhotoItem
    {
        public string ImageSource { get; set; } = "image_placeholder.png";
        public bool IsAddButton { get; set; } = false;
    }
}
