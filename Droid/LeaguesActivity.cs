using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    [Activity(Label = "Leagues", MainLauncher = true, Icon = "@mipmap/icon")]
    public class LeaguesActivity : ListActivity
    {
        DataManager dataManager = new DataManager();
        IList<League> leagues;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            leagues = (IList<League>)await dataManager.GetAllLeagues();
            ListAdapter = new LeaguesListAdapter(this,leagues);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var intent = new Intent(this, typeof(LeagueDetailActivity));
            intent.PutExtra("league", leagues[position].Name);
            intent.PutExtra("id", leagues[position].Id);
            StartActivity(intent);
        }
    }
}

