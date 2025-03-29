using Microsoft.Maui.Controls;
using OutdoorShareMauiApp.Services;
using System.Threading.Tasks;
using System.IO;

namespace OutdoorShareMauiApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public List<SkiMaterial> Materials { get; set; }

        public HomePage()
        {
            InitializeComponent();
            var viewModel = new HomePageViewModel();
            BindingContext = viewModel;
            Task.Run(async () => await LoadMaterialsAsync(viewModel));
        }

        private async Task LoadMaterialsAsync(HomePageViewModel viewModel)
        {
            await viewModel.LoadSkiMaterialsAsync();
            this.Materials = viewModel.SkiMaterials;
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
