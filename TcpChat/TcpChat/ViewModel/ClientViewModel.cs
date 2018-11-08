using System.ComponentModel;
using System.Windows.Input;
using TcpChat.Model;
using TcpChat.View;
using Xamarin.Forms;

namespace TcpChat.ViewModel
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        TcpChatClient _tcpClient;
        public INavigation Navigation { get; set; }
        public ICommand EnterToChatCommand { protected set; get; }
        public ICommand SendMessageCommand { protected set; get; }
        public ICommand LeaveChatCommand { protected set; get; }
        public string Name { get; set; }
        public string InputMessage { get; set; }
        public string OutputMessage { get; set; }

        public ClientViewModel()
        {
            _tcpClient = new TcpChatClient();
            _tcpClient.ReceivedMessageEvent += (a) => { InputMessage += a + "\n"; OnPropertyChanged("InputMessage"); };
            EnterToChatCommand = new Command(EnterToChat);
            SendMessageCommand = new Command(SendMessage);
            LeaveChatCommand = new Command(LeaveChat);
        }

        private void EnterToChat()
        {
            _tcpClient.StartClient(Name);
            Navigation.PushAsync(new ChatRoomPage(this));
        }

        private void SendMessage()
        {
            _tcpClient.SendMessage(OutputMessage);
            OutputMessage = "";
        }

        private void LeaveChat()
        {
            _tcpClient.SendMessage("278_01close");
            Name = InputMessage = OutputMessage = "";

            OnPropertyChanged("Name");
            OnPropertyChanged("InputMessage");
            OnPropertyChanged("OutputMessage");
            Navigation.PopAsync();
        }


        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
