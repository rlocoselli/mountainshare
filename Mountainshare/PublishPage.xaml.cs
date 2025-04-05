using System;
using System.Collections.ObjectModel;
using System.Linq;
using OutdoorShareMauiApp.Helpers;
using Microsoft.Maui.Controls;
//using Microsoft.Maui.Essentials;

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
