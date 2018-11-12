using Android.Content;
using TcpChat.DependencyServices.Defaults;

[assembly: Xamarin.Forms.Dependency(typeof(TcpChat.Droid.SharedPref))]
namespace TcpChat.Droid
{
    class SharedPref : IDefaults
    {
        public string PREF_NAME { get; set; } = "Name";

        public string GetUserName()
        {
            return MainActivity._settings.GetString(PREF_NAME, "AnyName");
        }

        public void SaveUserName(string userName)
        {
            ISharedPreferencesEditor edit = MainActivity._settings.Edit();
            edit.PutString(PREF_NAME, userName);
            edit.Apply();
        }
    }
}