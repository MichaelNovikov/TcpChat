using Prism.Navigation;
using System;
using System.Threading;
using System.Threading.Tasks;
using TcpChat.DependencyServices.Notifications;
using Xamarin.Forms;

namespace TcpChat
{
    public partial class MainPage : ContentPage, IConfirmNavigation
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

    }
}
