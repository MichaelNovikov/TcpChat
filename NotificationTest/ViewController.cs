using Foundation;
using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;

namespace NotificationTest
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

             Method();
            //UIApplication.SharedApplication.EndBackgroundTask(taskID);
       
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void Method()
        {
            var notification = new UILocalNotification();
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(1);
            notification.AlertAction = "Test";
            notification.AlertBody = "Test Text";
            notification.ApplicationIconBadgeNumber = 1;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }

        partial void BtnNotification_TouchUpInside(UIButton sender)
        {
            var notification = new UILocalNotification();
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(1);
            notification.AlertAction = "Test";
            notification.AlertBody = "Test Text";
            notification.ApplicationIconBadgeNumber = 1;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}