using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class PlayersListAdapter : BaseAdapter<Player>
    {
        IList<Player> players;
        Activity context;

        public PlayersListAdapter(Activity context, IList<Player> players)
        {
            this.players = players;
            this.context = context;
        }

        public override Player this[int position]
        {
            get { return players[position]; }
        }

        public override int Count
        {
            get { return players.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            Player player = players[position];
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = player.jerseyNumber + "\t" + player.name;
            return view;
        }
    }   
}
