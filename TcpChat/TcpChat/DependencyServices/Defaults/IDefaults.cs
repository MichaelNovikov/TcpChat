namespace TcpChat.DependencyServices.Defaults
{
    public interface IDefaults
    {
        void SaveUserName(string userName);
        string GetUserName();
        string PREF_NAME { get; set; }
    }
}
