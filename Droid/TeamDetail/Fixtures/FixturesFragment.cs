using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class FixturesFragment : Android.Support.V4.App.ListFragment
    {
        ApiDataManager DataManager = new ApiDataManager();
        IList<Fixture> Fixtures;
        Team Team;

        public FixturesFragment(Team team)
        {
            Team = team;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.NotFound, container, false);
            return view;
        }

        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Response<IEnumerable<Fixture>> response = await DataManager.GetFixtures(Team);
            if (response.Success)
            {
                Fixtures = (IList<Fixture>)response.Data;
                if (Fixtures.Count > 0)
                {
                    ListAdapter = new FixturesListAdapter(Activity, Fixtures);
                }
                else
                {
                    View.FindViewById<TextView>(Resource.Id.errorMessage).Text = "Fixtures not found";
                }
            }
            else
            {
                View.FindViewById<TextView>(Resource.Id.errorMessage).Text = response.Message;
            }
        }
    }
}
