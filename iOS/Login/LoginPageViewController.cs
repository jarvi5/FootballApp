using System;
using UIKit;
using Firebase.Auth;
using FootballApp.Helpers;
using Foundation;

namespace FootballApp.iOS
{
    public partial class LoginPageViewController : UIViewController
    {
        Auth Auth;

        public LoginPageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Auth = Auth.DefaultInstance;
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);
            var handle = Auth.DefaultInstance.AddAuthStateDidChangeListener(HandleAuthStateDidChangeListener);
		}

		async partial void LoginButton_TouchUpInside(UIButton sender)
        {
            if (!Validations.IsValidEmail(EmailTextView.Text))
            {
                InvokeOnMainThread(() => {
                    this.EmailTextView.BackgroundColor = UIColor.Yellow;
                    this.EmailTextView.Layer.BorderColor = UIColor.Red.CGColor;
                    this.EmailTextView.Layer.BorderWidth = 3;
                    this.EmailTextView.Layer.CornerRadius = 5;
                });
                return;
            }
            else
            {
                InvokeOnMainThread(() =>
                {
                    this.EmailTextView.BackgroundColor = UIColor.Clear;
                    this.EmailTextView.Layer.BorderColor = UIColor.Clear.CGColor;
                    this.EmailTextView.Layer.BorderWidth = 3;
                    this.EmailTextView.Layer.CornerRadius = 5;
                });
            }
            try
            {
                User user = await Auth.DefaultInstance.SignInAsync(EmailTextView.Text, PasswordTextView.Text);
            }
            catch(NSErrorException ex)
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Error",
                    Message = ex.Error.LocalizedDescription
                };
                alert.AddButton("Ok");
                alert.Show();
            }
        }

        void HandleAuthStateDidChangeListener(Auth auth, User user)
        {
            if(user != null)
            {
                var storyboard = UIStoryboard.FromName("Main", NSBundle.MainBundle);
                var mainController = storyboard.InstantiateViewController("MainNavigationController");
                PresentViewController(mainController, true, null);
            }
        }
    }
}