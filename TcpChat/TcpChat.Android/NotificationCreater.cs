using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.App;
using System;
using TcpChat.DependencyServices.Notifications;

[assembly: Xamarin.Forms.Dependency(typeof(TcpChat.Droid.NotificationCreater))]
namespace TcpChat.Droid
{
    class NotificationCreater : INotificationCreater
    {
        public void CreateNotification(string message)
        {
            var random = new Random();
            int messageId = random.Next(0, 1000);
            var intent = new Intent(Application.Context, typeof(MainActivity));
            var pending = PendingIntent.GetActivity(Application.Context, random.Next(0, 1000), intent, PendingIntentFlags.CancelCurrent);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context, "channelId")
                .SetAutoCancel(true)
                .SetContentTitle(DateTime.Now.ToShortTimeString())
                .SetContentText(message)
                .SetContentIntent(pending)
                .SetCategory(Notification.CategoryMessage)
                .SetPriority((int)NotificationPriority.High)
                .SetSmallIcon(Resource.Drawable.chattingSmall)
                .SetLargeIcon(BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.chattingBig))
                .SetStyle(new NotificationCompat.BigPictureStyle().BigPicture(BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.MCHorizontal)));
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                builder.SetVisibility(1);
            }

            NotificationManager notificationManager = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(messageId, builder.Build());
        }

        public void CancelAllNotifications()
        {
            NotificationManager notificationManager = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);
            notificationManager.CancelAll();
        }
    }
}