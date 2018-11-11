namespace TcpChat.DependencyServices.Notifications
{
    public interface INotificationCreater
    {
        void CreateNotification(string message);
        void CancelAllNotifications();
    }
}
