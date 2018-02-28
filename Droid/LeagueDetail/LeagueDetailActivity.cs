using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using FootballApp.Data;

namespace FootballApp.Droid
{
    [Activity(Label = "League Detail")]
    public class LeagueDetailActivity : ListActivity
    {

        IList<Team> Teams;
        IDataManager<string> DataManager = new ApiDataManager();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Title = Intent.GetStringExtra("league");
            await DataManager.LoadData("http://www.football-data.org/v1/competitions/"+ Intent.GetIntExtra("id",-1) + "/leagueTable");
            Teams = (IList<Team>)DataManager.GetLeagueTable();
            ListAdapter = new TeamsListAdapter(this, Teams);
        }

        protected override void OnListItemClick(Android.Widget.ListView l, Android.Views.View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var intent = new Intent(this, typeof(TeamDetailActivity));
            intent.PutExtra("teamUrl",Teams[position].Links.Team.Href);
            intent.PutExtra("teamName",Teams[position].TeamName);
            StartActivity(intent);
        }
    }
}
