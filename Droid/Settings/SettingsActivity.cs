
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;

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
            TextView emailTextView = FindViewById<TextView>(Resource.Id.emailTextView);
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            emailTextView.Text = preferences.GetString("email", "");
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            logoutButton.Click += OnLogoutButtonClick;
        }

        void OnLogoutButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(LoginActivity));
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = preferences.Edit();
            editor.PutBoolean("isAuthenticated", false);
            editor.Remove("email");
            editor.Commit();
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}
