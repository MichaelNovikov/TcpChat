using Foundation;
using System;
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
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnNotification_TouchUpInside(UIButton sender)
        {
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