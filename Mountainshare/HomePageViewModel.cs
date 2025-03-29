using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutdoorShareMauiApp.Services;

namespace OutdoorShareMauiApp
{
    public class HomePageViewModel
    {
        public List<SkiMaterial> SkiMaterials { get; set; }
        public async Task LoadSkiMaterialsAsync()
        {
            var apiService = new ApiService();
            SkiMaterials = await apiService.GetSkiMaterialsAsync();
        }
    }
}
