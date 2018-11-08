using Prism.Navigation;
using System;
using TcpChat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TcpChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoomPage : ContentPage, INavigatedAware, IConfirmNavigation
    {
        public ChatRoomPage()
        {
            InitializeComponent();
            btnSend.Clicked += ClearEntry;
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            BindingContext = parameters["Param"] as ClientViewModel;
        }

        private void ClearEntry(object sender, EventArgs args)
        {
            entryTxt.Text = "";
        }
    }
}