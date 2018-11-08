﻿using Plugin.LocalNotifications;
using Prism.AppModel;
using Prism.Navigation;
using System.ComponentModel;
using System.Windows.Input;
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
        public string Name { get; set; }
        public string InputMessage { get; set; }
        public string OutputMessage { get; set; }
        private string CurrentMessge { get; set; }


        public ClientViewModel(INavigationService navigationServe)
        {
            NavigationService = navigationServe;
            _tcpClient = new TcpChatClient();
            _tcpClient.ReceivedMessageEvent += (a) => { InputMessage += a + "\n"; OnPropertyChanged("InputMessage"); CurrentMessge = a; };
            EnterToChatCommand = new Command(EnterToChat);
            SendMessageCommand = new Command(SendMessage);
            LeaveChatCommand = new Command(LeaveChat);
        }

        private async void EnterToChat()
        {
            _tcpClient.StartClient(Name);
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
            Name = InputMessage = OutputMessage = "";

            OnPropertyChanged("Name");
            OnPropertyChanged("InputMessage");
            OnPropertyChanged("OutputMessage");
            await NavigationService.GoBackAsync();
        }

        private void Notificate()
        {

        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void OnResume()
        {
            CrossLocalNotifications.Current.Show("title", "OnResume");
        }

        public void OnSleep()
        {
            CrossLocalNotifications.Current.Show("title", "OnSleep");
        }
    }
}
