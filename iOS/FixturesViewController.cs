using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;

namespace FootballApp.iOS
{
    public class FixturesViewController : UITableViewController
    {
        public string teamUrl { get; set; }
        DataManager dataManager = new DataManager();
        IList<Fixture> fixtures;

        public FixturesViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            fixtures = (IList<Fixture>)await dataManager.GetFixtures(teamUrl);
            TableView.Source = new FixturesViewControllerSource<Fixtures>(TableView)
            {
                DataSource = fixtures,
                Text = fixture => fixture.homeTeamName + " vs " + fixture.awayTeamName,
                Detail = fixture => "Date: " + fixture.date + "\tScore: " + fixture.result.goalsHomeTeam + " - " + fixture.result.goalsAwayTeam
            };
        }
    }
}
