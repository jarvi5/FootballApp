﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class LeaguesListAdapter : BaseAdapter<League>
    {

        IList<League> leagues;
        Activity context;

        public LeaguesListAdapter(Activity context, IList<League> leagues)
        {
            this.leagues = leagues;
            this.context = context;
        }

        public override League this[int position]
        {
            get { return leagues[position]; }
        }

        public override int Count
        {
            get { return leagues.Count; }
        }

        public override long GetItemId(int position)
        {
            return leagues[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = leagues[position].caption;
            return view;
        }
    }
}
