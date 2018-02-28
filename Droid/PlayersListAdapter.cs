using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class PlayersListAdapter : BaseAdapter<Player>
    {
        IList<Player> Players;
        Activity Context;

        public PlayersListAdapter(Activity context, IList<Player> players)
        {
            Players = players;
            Context = context;
        }

        public override Player this[int position]
        {
            get { return Players[position]; }
        }

        public override int Count
        {
            get { return Players.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = Context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            Player player = Players[position];
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = player.JerseyNumber + "\t" + player.Name;
            return view;
        }
    }   
}
