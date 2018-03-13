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
    [Activity(Label = "Leagues")]
    public class LeaguesActivity : ListActivity
    {
        IDataManager DataManager = new ApiDataManager();
        IList<League> Leagues;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Response<IEnumerable<League>> response = await DataManager.GetAllLeagues();
            if (response.Success)
            {
                SetContentView(Resource.Layout.Leagues);
                var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                SetActionBar(toolbar);
                Leagues = (IList<League>)response.Data;
                ListAdapter = new LeaguesListAdapter(this, Leagues);
            }
            else
            {
                SetContentView(Resource.Layout.NotFound);
                var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                FindViewById<TextView>(Resource.Id.errorMessage).Text = response.Message;
                SetActionBar(toolbar);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.topMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (Equals(item.TitleFormatted.ToString(),"Settings"))
            {
                var intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var intent = new Intent(this, typeof(LeagueDetailActivity));
            string league = Serialization<League>.Serialize(Leagues[position]);
            intent.PutExtra("league", league);
            StartActivity(intent);
        }
    }
}

