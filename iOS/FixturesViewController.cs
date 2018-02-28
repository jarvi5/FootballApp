using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;

namespace FootballApp.iOS
{
    public class FixturesViewController : UITableViewController
    {
        public string TeamUrl { get; set; }
        DataManager DataManager = new DataManager();
        IList<Fixture> Fixtures;

        public FixturesViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Fixtures = (IList<Fixture>)await DataManager.GetFixtures(TeamUrl);
            TableView.Source = new FixturesViewControllerSource<Fixtures>(TableView)
            {
                DataSource = Fixtures,
                Text = fixture => fixture.HomeTeamName + " vs " + fixture.AwayTeamName,
                Detail = fixture => "Date: " + fixture.Date + "\tScore: " + fixture.Result.GoalsHomeTeam + " - " + fixture.Result.GoalsAwayTeam
            };
        }
    }
}
