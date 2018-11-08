using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpChat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TcpChat.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatRoomPage : ContentPage
	{
		public ChatRoomPage (ClientViewModel clientViewModel)
		{
			InitializeComponent ();
            BindingContext = clientViewModel;
            btnSend.Clicked += ClearEntry;
		}

        private void ClearEntry(object sender, EventArgs args)
        {
            entryTxt.Text = "";
        }
	}
}