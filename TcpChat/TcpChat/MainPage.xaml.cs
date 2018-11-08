using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpChat.ViewModel;
using Xamarin.Forms;

namespace TcpChat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ClientViewModel() { Navigation = this.Navigation };
        }
    }
}
