using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Firebase.Auth;

namespace FootballApp.Droid
{
    [Activity(Label = "Settings")]
    public class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Settings);
            Button logoutButton = FindViewById<Button>(Resource.Id.logoutButton);
            FindViewById<TextView>(Resource.Id.emailTextView).Text = FirebaseAuth.Instance.CurrentUser.Email;
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            logoutButton.Click += OnLogoutButtonClick;
        }

        void OnLogoutButtonClick(object sender, EventArgs e)
        {
            FirebaseAuth.Instance.SignOut();
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }
    }
}
