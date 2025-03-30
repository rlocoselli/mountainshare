using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutdoorShareMauiApp.Services;

namespace OutdoorShareMauiApp
{
    public class HomePageViewModel
    {
        public ObservableCollection<SkiMaterial> SkiMaterials { get; set; }

        public HomePageViewModel()
        {
            SkiMaterials = new ObservableCollection<SkiMaterial>();
        }

        public async Task LoadSkiMaterialsAsync()
        {
            var apiService = new ApiService();
            var materials = await apiService.GetSkiMaterialsAsync();
            foreach (var material in materials)
            {
                SkiMaterials.Add(material);
            }
        }
    }
}
