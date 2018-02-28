using Android.App;
using Android.OS;
using Android.Util;

namespace FootballApp.Droid
{
    [Activity(Label = "Team Detail")]
    public class TeamDetailActivity : Activity
    {
        Fragment[] Fragments;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.TeamDetail);
            Title = Intent.GetStringExtra("teamName");

            Fragments = new Fragment[]
            {
                new PlayersFragment(Intent.GetStringExtra("teamUrl")),
                new FixturesFragment(Intent.GetStringExtra("teamUrl"))
            };

            AddTabToActionBar(Resource.String.players_label);
            AddTabToActionBar(Resource.String.fixture_label);
        }

        void AddTabToActionBar(int labelResourceId)
        {
            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(labelResourceId);
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;

            Log.Debug("The tab {0} has been selected.", tab.Text);
            Fragment fragment = Fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout, fragment);
        }

    }
}