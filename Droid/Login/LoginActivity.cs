using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Firebase.Auth;
using FootballApp.Helpers;

namespace FootballApp.Droid
{
    [Activity(Label = "Login")]
    public class LoginActivity : Activity
    {
        Button LoginButton;
        EditText EmailEditText;
        EditText PasswordEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            LoginButton = FindViewById<Button>(Resource.Id.loginButton);
            EmailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            PasswordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            LoginButton.Click += OnLoginButtonClick;
        }

		async void OnLoginButtonClick(object sender, EventArgs e)
        {
            string email = EmailEditText.Text;
            string password = PasswordEditText.Text;
            if(!Validations.IsValidEmail(email))
            {
                EmailEditText.Error = "Invalid email address";
                return;
            }
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            }
            catch
            {
                Toast.MakeText(this, "Sign In failed", ToastLength.Short).Show();
            }
        }

        public void AuthStateChanged(object sender, FirebaseAuth.AuthStateEventArgs e)
        {
            var user = e.Auth.CurrentUser;

            if (user != null)
            {
                var intent = new Intent(this, typeof(LeaguesActivity));
                StartActivity(intent);
                Finish();
            }
        }


        protected override void OnStart()
        {
            base.OnStart();

            FirebaseAuth.Instance.AuthState += AuthStateChanged;
        }

        protected override void OnStop()
        {
            base.OnStop();

            FirebaseAuth.Instance.AuthState -= AuthStateChanged;
        }
    }
}
