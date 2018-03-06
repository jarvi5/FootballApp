using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.App;

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
    }
}