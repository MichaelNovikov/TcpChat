using Foundation;
using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;

namespace NotificationTest
{
    public partial class ViewController : UIViewController
    {

        public string PREF_NAME { get; set; } = "Name";

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            TextFild.Text = GetUserName();

            //runs on main or background thread
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

       
        public string GetUserName()
        {
            return NSUserDefaults.StandardUserDefaults.StringForKey(PREF_NAME);
        }

        public void SaveUserName(string userName)
        {
            NSUserDefaults.StandardUserDefaults.SetString(userName, PREF_NAME);
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

            SaveUserName(TextFild.Text);
        }
    }
}