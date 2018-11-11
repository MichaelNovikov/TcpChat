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
            
        }

        public void CreateNotification(string message)
        {
            //UILocalNotification notification = new UILocalNotification();
            //notification.FireDate = NSDate.FromTimeIntervalSinceNow(15);
            //notification.AlertAction = DateTime.Now.ToShortTimeString();
            //notification.AlertBody = message;
            //notification.ApplicationIconBadgeNumber = 1;
            //UIApplication.SharedApplication.ScheduleLocalNotification(notification);

            var notification = new UILocalNotification();
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(5);
            notification.AlertAction = "Test";
            notification.AlertBody = "Test Text";
            notification.ApplicationIconBadgeNumber = 1;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}