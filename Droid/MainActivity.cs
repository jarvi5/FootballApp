using Android.App;
using Android.Content;
using Android.OS;
using Firebase.Auth;

namespace FootballApp.Droid
{
    [Activity(Label = "", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        bool isAuthenticated 
        {
            get
            {
                return FirebaseAuth.Instance.CurrentUser != null;
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
