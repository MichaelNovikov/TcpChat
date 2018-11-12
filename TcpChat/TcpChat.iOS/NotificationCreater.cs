 using Foundation;
using System;
using TcpChat.DependencyServices.Notifications;
using UIKit;
using UserNotifications;

[assembly: Xamarin.Forms.Dependency(typeof(TcpChat.iOS.NotificationCreater))]
namespace TcpChat.iOS
{
    class NotificationCreater : INotificationCreater
    {
        public void CancelAllNotifications()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests(); // To remove all pending notifications which are not delivered yet but scheduled.
                UNUserNotificationCenter.Current.RemoveAllDeliveredNotifications(); // To remove all delivered notifications
            }
            else
            {
                UIApplication.SharedApplication.CancelAllLocalNotifications();
            }
        }

        public void CreateNotification(string message)
        {
            var notification = new UILocalNotification();
            notification.AlertAction = message ?? "Test";
            notification.AlertBody = "Test Text";
            notification.ApplicationIconBadgeNumber = 1;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}