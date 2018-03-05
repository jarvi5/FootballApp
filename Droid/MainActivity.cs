
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FootballApp.Droid
{
    [Activity(Label = "", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        bool isAuthenticated 
        {
            get
            {
                ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
                return preferences.GetBoolean("isAuthenticated", false);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (isAuthenticated)
            {
                var intent = new Intent(this, typeof(LeaguesActivity));
                StartActivity(intent);
            }
            else{
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }
            Finish();
        }
    }
}
