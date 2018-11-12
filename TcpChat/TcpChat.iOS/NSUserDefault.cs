using Foundation;
using System;
using TcpChat.DependencyServices.Defaults;

[assembly: Xamarin.Forms.Dependency(typeof(TcpChat.iOS.NSUserDefault))]
namespace TcpChat.iOS
{
    class NSUserDefault : IDefaults
    {
        public string PREF_NAME { get; set; } = "Name";

        public string GetUserName()
        {
            return NSUserDefaults.StandardUserDefaults.StringForKey(PREF_NAME);
        }

        public void SaveUserName(string userName)
        {
            NSUserDefaults.StandardUserDefaults.SetString(userName, "AnyName");
        }

        public void ClearName()
        {
            NSUserDefaults.StandardUserDefaults.RemoveObject(PREF_NAME);
        }
    }
}