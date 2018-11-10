using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpChat.ViewModel;
using Xamarin.Forms;

namespace TcpChat
{
    public partial class MainPage : ContentPage, IConfirmNavigation 
    {
        public MainPage()
        {
            InitializeComponent();
            entryName.Text = "";
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

    }
}
