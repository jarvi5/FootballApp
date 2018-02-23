using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using FootballApp.Data;
using Java.IO;
using Java.Net;
using Square.Picasso;

namespace FootballApp.Droid
{
    public class TeamsListAdapter : BaseAdapter<Team>
    {
        IList<Team> teams;
        Activity context;

        public TeamsListAdapter(Activity context, IList<Team> teams)
        {
            this.teams = teams;
            this.context = context;
        }

        public override Team this[int position]
        {
            get { return teams[position]; }
        }

        public override int Count
        {
            get { return teams.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Team item = teams[position];
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Resource.Layout.TeamCellView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.teamName;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = "position: " + item.position + "\tpoints: " + item.points;
            if (!string.IsNullOrEmpty(item.crestURI))
            {
                ImageView image = view.FindViewById<ImageView>(Resource.Id.Image);
                Picasso.With(context).Load(item.crestURI).Into(image);
            }
            return view;
        }
    }
}
