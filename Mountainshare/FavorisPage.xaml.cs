using Microsoft.Maui.Controls;
using OutdoorShareMauiApp.Helpers;

namespace OutdoorShareMauiApp.Pages
{
    public partial class FavorisPage : BaseProtectedPage
    {
        public FavorisPage()
        {
            InitializeComponent();
        }

        protected override bool IsUserLoggedIn => false;
    }
}