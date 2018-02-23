using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using FootballApp.Data;

namespace FootballApp.Droid
{
    [Activity(Label = "League Detail")]
    public class LeagueDetailActivity : ListActivity
    {

        IList<Team> Teams;
        DataManager dataManager = new DataManager();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Title = Intent.GetStringExtra("league");
            Teams = (IList<Team>)await dataManager.GetLeagueTable(Intent.GetIntExtra("id",-1));
            ListAdapter = new TeamsListAdapter(this, Teams);
        }
    }
}
