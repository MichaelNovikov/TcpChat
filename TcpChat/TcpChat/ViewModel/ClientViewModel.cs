﻿using Prism.AppModel;
using Prism.Navigation;
using System.ComponentModel;
using System.Windows.Input;
using TcpChat.DependencyServices.Defaults;
using TcpChat.DependencyServices.Notifications;
using TcpChat.Model;
using Xamarin.Forms;

namespace TcpChat.ViewModel
{
    public class ClientViewModel : INotifyPropertyChanged, IApplicationLifecycleAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        TcpChatClient _tcpClient;
        public INavigationService NavigationService { get; set; }
        public ICommand EnterToChatCommand { protected set; get; }
        public ICommand SendMessageCommand { protected set; get; }
        public ICommand LeaveChatCommand { protected set; get; }
        public string Name { get; set; } = DependencyService.Get<IDefaults>().GetUserName();
        public string InputMessage { get; set; }
        public string OutputMessage { get; set; }
        private bool onSleep = false;

        public ClientViewModel(INavigationService navigationServe)
        {
            NavigationService = navigationServe;
            _tcpClient = new TcpChatClient();
            _tcpClient.ReceivedMessageEvent += (a) => { InputMessage += a + "\n"; OnPropertyChanged("InputMessage"); Notificate(a); };
            EnterToChatCommand = new Command(EnterToChat);
            SendMessageCommand = new Command(SendMessage);
            LeaveChatCommand = new Command(LeaveChat);
        }

        private async void EnterToChat()
        {
            if (Name == "")
                return;
            DependencyService.Get<IDefaults>().SaveUserName(Name);
            _tcpClient.StartClient(Name);
            Name = "";
            var parameter = new NavigationParameters();
            parameter.Add("Param", this);
            await NavigationService.NavigateAsync("ChatRoomPage", parameter);
        }

        private void SendMessage()
        {
            _tcpClient.SendMessage(OutputMessage);
            OutputMessage = "";
        }

        private async void LeaveChat()
        {
            _tcpClient.SendMessage("278_01close");
            InputMessage = OutputMessage = "";
            OnPropertyChanged("Name");
            OnPropertyChanged("InputMessage");
            OnPropertyChanged("OutputMessage");
            await NavigationService.GoBackAsync();
        }

        private void Notificate(string message)
        {   
            if (onSleep)
            {
                DependencyService.Get<INotificationCreater>().CreateNotification(message);
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void OnResume()
        {
            if (onSleep)
            DependencyService.Get<INotificationCreater>().CancelAllNotifications();
            onSleep = false;
        }

        public void OnSleep()
        {
            onSleep = true;
        }
    }
}
