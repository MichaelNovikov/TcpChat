using Foundation;
using System;
using TcpChat.DependencyServices.Notifications;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(TcpChat.iOS.NotificationCreater))]
namespace TcpChat.iOS
{
    class NotificationCreater : INotificationCreater
    {
        public void CancelAllNotifications()
        {
            throw new NotImplementedException();
        }

        public void CreateNotification(string message)
        {
            UILocalNotification notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(15);
            notification.AlertAction = DateTime.Now.ToShortTimeString();
            notification.AlertBody = message;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}