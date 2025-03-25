using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace OutdoorShareMauiApp.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ObservableCollection<string> Images { get; set; }

        public ProfilePage()
        {
            InitializeComponent();

            Images = new ObservableCollection<string>
            {
                @"http://www.meubusao.com/images/ic_launcher2.png",
            };

            BindingContext = Images;
        }
    }
}