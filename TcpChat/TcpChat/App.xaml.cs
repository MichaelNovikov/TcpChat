using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Net;
using TcpChat.View;
using TcpChat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TcpChat
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer) { }

        protected async override void OnInitialized()
        {
            InitializeComponent();
#if DEBUG
            LiveReload.Init();
#endif
           await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, ClientViewModel>();
            containerRegistry.RegisterForNavigation<ChatRoomPage>();
        }



        protected override void OnStart()
        {
            base.OnStart();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            base.OnResume();
            // Handle when your app resumes
        }
    }
}
