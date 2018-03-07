using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace FootballApp.Droid
{
    [Activity(Label = "Team Detail")]
    public class TeamDetailActivity : FragmentActivity
    {
        Android.Support.V4.App.Fragment[] Fragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TeamDetail);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            Title = Intent.GetStringExtra("teamName");
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            Fragments = new Android.Support.V4.App.Fragment[]
            {
                new PlayersFragment(Intent.GetStringExtra("teamUrl")),
                new FixturesFragment(Intent.GetStringExtra("teamUrl"))
            };

            TeamAdapter teamAdapter = new TeamAdapter(SupportFragmentManager, Fragments);
            viewPager.Adapter = teamAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.topMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(Equals(item.TitleFormatted.ToString(), "Settings"))
            {
                var intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}