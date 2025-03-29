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
    }
}
