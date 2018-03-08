using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using FootballApp.Data;
using FootballApp.Helpers;

namespace FootballApp.Droid
{
    [Activity(Label = "League Detail")]
    public class LeagueDetailActivity : ListActivity
    {

        IList<Team> Teams;
        League League;
        IDataManager DataManager = new ApiDataManager();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            League = Serialization<League>.Deserialize(Intent.GetStringExtra("league"));
            Response<IEnumerable<Team>> response = await DataManager.GetLeagueTable(League);
            if (response.Success)
            {
                Teams = (IList<Team>)response.Data;
                if (Teams != null)
                {
                    SetContentView(Resource.Layout.Leagues);
                    var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                    SetActionBar(toolbar);
                    Title = League.Name;
                    ListAdapter = new TeamsListAdapter(this, Teams);
                }
                else
                {
                    SetContentView(Resource.Layout.NotFound);
                    var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                    FindViewById<TextView>(Resource.Id.errorMessage).Text = "No teams found";
                    SetActionBar(toolbar);
                    Title = League.Name;
                }
            }
            else
            {
                SetContentView(Resource.Layout.NotFound);
                var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                FindViewById<TextView>(Resource.Id.errorMessage).Text = response.Message;
                SetActionBar(toolbar);
                Title = League.Name;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.topMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (Equals(item.TitleFormatted.ToString(), "Settings"))
            {
                var intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnListItemClick(ListView l, Android.Views.View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var intent = new Intent(this, typeof(TeamDetailActivity));
            string team = Serialization<Team>.Serialize(Teams[position]);
            intent.PutExtra("team", team);
            StartActivity(intent);
        }
    }
}
