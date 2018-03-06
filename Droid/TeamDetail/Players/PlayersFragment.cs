using System.Collections.Generic;
using Android.OS;
using Android.Views;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class PlayersFragment : Android.Support.V4.App.ListFragment
    {
        ApiDataManager DataManager = new ApiDataManager();
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
            await DataManager.LoadData(TeamUrl + "/players");
            Players = (IList<Player>)DataManager.GetPlayers();
            ListAdapter = new PlayersListAdapter(Activity, Players);
        }
    }
}
