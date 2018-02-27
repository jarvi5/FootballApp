using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FootballApp.Data;


namespace FootballApp.Droid
{
    public class FixturesListAdapter : BaseAdapter<Fixture>
    {
        IList<Fixture> fixtures;
        Activity context;

        public FixturesListAdapter(Activity context, IList<Fixture> fixtures)
        {
            this.fixtures = fixtures;
            this.context = context;
        }

        public override Fixture this[int position]
        {
            get
            {
                return fixtures[position];    
            }
        }

        public override int Count
        {
            get { return fixtures.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            Fixture fixture = fixtures[position];
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = fixture.homeTeamName + " vs " + fixture.awayTeamName;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = "Date: " + fixture.date + "\tScore: " + fixture.result.goalsHomeTeam + " - " + fixture.result.goalsAwayTeam;
            return view;
        }
    }
}
