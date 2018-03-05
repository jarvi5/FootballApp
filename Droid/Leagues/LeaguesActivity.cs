using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    [Activity(Label = "Leagues")]
    public class LeaguesActivity : ListActivity
    {
        IDataManager<string> DataManager = new ApiDataManager();
        IList<League> Leagues;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            await DataManager.LoadData("http://www.football-data.org/v1/competitions/?season=2017");
            Leagues = (IList<League>)DataManager.GetAllLeagues();
            ListAdapter = new LeaguesListAdapter(this,Leagues);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var intent = new Intent(this, typeof(LeagueDetailActivity));
            intent.PutExtra("league", Leagues[position].Name);
            intent.PutExtra("id", Leagues[position].Id);
            StartActivity(intent);
        }
    }
}

