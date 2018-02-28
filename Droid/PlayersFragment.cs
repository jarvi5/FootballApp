using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class PlayersFragment : ListFragment
    {
        DataManager DataManager = new DataManager();
        IList<Player> Players;
        string TeamUrl;

        public PlayersFragment (string url){
            TeamUrl = url;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Players = (IList<Player>)await DataManager.GetPlayers(TeamUrl);
            ListAdapter = new PlayersListAdapter(Activity, Players);
        }
    }
}
