using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Views;
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
            catch (Exception ex)
            {
                Toast.MakeText(this, "Sign In failed", ToastLength.Short).Show();
            }
            var user = FirebaseAuth.Instance.CurrentUser;
            if (user != null) {
                var intent = new Intent(this, typeof(LeaguesActivity));
                ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = preferences.Edit();
                editor.PutBoolean("isAuthenticated", true);
                editor.PutString("email", user.Email);
                editor.Commit();
                StartActivity(intent);
                Finish();
            }
        }
    }
}
