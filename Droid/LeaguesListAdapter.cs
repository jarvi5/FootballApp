using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class LeaguesListAdapter : BaseAdapter<League>
    {

        IList<League> Leagues;
        Activity Context;

        public LeaguesListAdapter(Activity context, IList<League> leagues)
        {
            Leagues = leagues;
            Context = context;
        }

        public override League this[int position]
        {
            get { return Leagues[position]; }
        }

        public override int Count
        {
            get { return Leagues.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = Context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = Leagues[position].Caption;
            return view;
        }
    }
}
