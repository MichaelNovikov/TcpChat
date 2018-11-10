using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using TcpChat.DependencyServices.Notifications;

[assembly: Xamarin.Forms.Dependency(typeof(TcpChat.Droid.NotificationCreater))]
namespace TcpChat.Droid
{
    class NotificationCreater : INotificationCreater
    {
        public void CreateNotification(string message)
        {
            int messageId = 1001;
            var intent = new Intent(Application.Context, typeof(MainActivity));
            var pending = PendingIntent.GetActivity(Application.Context, 0, intent, PendingIntentFlags.CancelCurrent);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context, "channelId")
                .SetAutoCancel(true)
                .SetContentTitle(DateTime.Now.ToShortTimeString())
                .SetContentIntent(pending)
                .SetSmallIcon(Resource.Drawable.chatting)
                .SetStyle(new NotificationCompat.BigTextStyle().BigText(message));

            NotificationManager notificationManager = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(messageId, builder.Build());
        }
    }
}