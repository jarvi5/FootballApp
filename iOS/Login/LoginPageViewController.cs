using System;
using UIKit;
using Firebase.Auth;
using FootballApp.Helpers;

namespace FootballApp.iOS
{
    public partial class LoginPageViewController : UIViewController
    {
        public event EventHandler OnLoginSuccess;
        Auth Auth;

        public LoginPageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Auth = Auth.DefaultInstance;
        }

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            if (Validations.IsValidEmail(EmailTextView.Text))
            {
                this.EmailTextView.BackgroundColor = UIColor.Clear;
                this.EmailTextView.Layer.BorderColor = UIColor.Clear.CGColor;
                this.EmailTextView.Layer.BorderWidth = 3;
                this.EmailTextView.Layer.CornerRadius = 5;
            }
            else
            {
                InvokeOnMainThread(() =>
                {
                    this.EmailTextView.BackgroundColor = UIColor.Yellow;
                    this.EmailTextView.Layer.BorderColor = UIColor.Red.CGColor;
                    this.EmailTextView.Layer.BorderWidth = 3;
                    this.EmailTextView.Layer.CornerRadius = 5;
                });   
            }

            if(String.Equals("javicamdo@gmail.com", EmailTextView.Text) && String.Equals("passwd123", PasswordTextView.Text))
            {
                OnLoginSuccess(sender, new EventArgs());
            }

            else
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Error",
                    Message = "Bad email or password"
                };
                alert.AddButton("Ok");
                alert.Show();
            }

            /*Auth.SignIn(EmailTextView.Text, PasswordTextView.Text, (user, error) => {
                if (user != null)
                {
                    OnLoginSuccess(sender, new EventArgs());
                }
                else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Error",
                        Message = error.LocalizedDescription
                    };
                    alert.AddButton("Ok");
                    alert.Show();
                }
            });*/
        }
    }
}