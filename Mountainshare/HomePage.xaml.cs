using Microsoft.Maui.Controls;
using OutdoorShareMauiApp.Services;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace OutdoorShareMauiApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<SkiMaterial> Materials { get; set; }

        public HomePage()
        {
            InitializeComponent();
            var viewModel = new HomePageViewModel();
            BindingContext = viewModel;
            LoadMaterialsAsync(viewModel);
        }

        private async void LoadMaterialsAsync(HomePageViewModel viewModel)
        {
            await viewModel.LoadSkiMaterialsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Materials = viewModel.SkiMaterials;
                materialsListView.ItemsSource = Materials;
            });
        }

        public class Base64ToImageSourceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is string base64String && !string.IsNullOrEmpty(base64String))
                {
                    byte[] imageBytes = System.Convert.FromBase64String(base64String);
                    return ImageSource.FromStream(() => new MemoryStream(imageBytes));
                }
                return null;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
