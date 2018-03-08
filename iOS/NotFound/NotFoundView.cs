using System;
using UIKit;
using ObjCRuntime;
using Foundation;

namespace FootballApp.iOS
{
    public partial class NotFoundView : UIView
    {
        public NotFoundView(IntPtr handle) : base(handle)
        {
        }

        public static NotFoundView Create(string message)
        {
            var arr = NSBundle.MainBundle.LoadNib("NotFoundView", null, null);
            var v = Runtime.GetNSObject<NotFoundView>(arr.ValueAt(0));
            v.Message.Text = message;
            return v;
        }
    }
}