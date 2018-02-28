using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FootballApp.Data;


namespace FootballApp.Droid
{
    public class FixturesListAdapter : BaseAdapter<Fixture>
    {
        IList<Fixture> Fixtures;
        Activity Context;

        public FixturesListAdapter(Activity context, IList<Fixture> fixtures)
        {
            Fixtures = fixtures;
            Context = context;
        }

        public override Fixture this[int position]
        {
            get
            {
                return Fixtures[position];    
            }
        }

        public override int Count
        {
            get { return Fixtures.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = Context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            Fixture fixture = Fixtures[position];
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = fixture.HomeTeamName + " vs " + fixture.AwayTeamName;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = "Date: " + fixture.Date + "\tScore: " + fixture.Result.GoalsHomeTeam + " - " + fixture.Result.GoalsAwayTeam;
            return view;
        }
    }
}
