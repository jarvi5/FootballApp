﻿using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class FixturesFragment : ListFragment
    {
        DataManager DataManager = new DataManager();
        IList<Fixture> Fixtures;
        string TeamUrl;

        public FixturesFragment(string url)
        {
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
            Fixtures = (IList<Fixture>)await DataManager.GetFixtures(TeamUrl);
            ListAdapter = new FixturesListAdapter(Activity, Fixtures);
        }
    }
}
