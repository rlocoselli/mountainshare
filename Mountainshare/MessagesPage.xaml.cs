using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OutdoorShareMauiApp.Pages
{
    public partial class MessagesPage : ContentPage
    {
        private ObservableCollection<MessageModel> allMessages;
        private ObservableCollection<MessageModel> filteredMessages;

        public MessagesPage()
        {
            InitializeComponent();

            allMessages = new ObservableCollection<MessageModel>
        {
            new MessageModel { Name = "Jean jean", LastMessage = "Hey, how are you doing today?", Image = "guide1.jpeg" },
            new MessageModel { Name = "Alex Johnson", LastMessage = "Hey, how are you doing today?", Image = "guide1.jpeg" },
            new MessageModel { Name = "moi", LastMessage = "Hey, how are you doing today?", Image = "guide1.jpeg" }
        };

            filteredMessages = new ObservableCollection<MessageModel>(allMessages);
            MessagesCollectionView.ItemsSource = filteredMessages;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue.ToLower();

            filteredMessages.Clear();

            foreach (var message in allMessages)
            {
                if (message.Name.ToLower().Contains(searchText))
                    filteredMessages.Add(message);
            }
        }

        private async void OnMessageTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrivateMessagePage());
        }
    }

    public class MessageModel
    {
        public string Name { get; set; }
        public string LastMessage { get; set; }
        public string Image { get; set; }
    }
}