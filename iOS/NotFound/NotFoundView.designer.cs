// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FootballApp.iOS
{
    [Register ("NotFoundView")]
    partial class NotFoundView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Message { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Message != null) {
                Message.Dispose ();
                Message = null;
            }
        }
    }
}