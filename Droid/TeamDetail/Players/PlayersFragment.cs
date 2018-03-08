using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class PlayersFragment : Android.Support.V4.App.ListFragment
    {
        IDataManager DataManager = new ApiDataManager();
        IList<Player> Players;
        Team Team;

        public PlayersFragment (Team team){
            Team = team;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.NotFound, container, false);
            return view;
        }

        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Response<IEnumerable<Player>> response = await DataManager.GetPlayers(Team);
            if(response.Success)
            {
                Players = (IList<Player>)response.Data;
                if(Players.Count > 0)
                {
                    ListAdapter = new PlayersListAdapter(Activity, Players);
                }
                else
                {
                    View.FindViewById<TextView>(Resource.Id.errorMessage).Text = "Players not found";
                }
            }
            else
            {
                View.FindViewById<TextView>(Resource.Id.errorMessage).Text = response.Message;
            }
        }
    }
}
