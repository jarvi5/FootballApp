using Foundation;
using System;
using UIKit;

namespace FootballApp.iOS
{
    public partial class SettingsViewController : UIViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EmailLabel.Text = NSUserDefaults.StandardUserDefaults.StringForKey("email");
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var login = segue.DestinationViewController as LoginPageViewController;
            if (login != null)
            {
                NSUserDefaults.StandardUserDefaults.SetBool(false, "isAuthenticated");
            }
        }
    }
}