using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;

namespace FootballApp.iOS
{
    public class FixturesViewController : UITableViewController
    {
        public string TeamUrl { get; set; }
        ApiDataManager DataManager = new ApiDataManager();
        IList<Fixture> Fixtures;

        public FixturesViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await DataManager.LoadData(TeamUrl + "/fixtures");
            Fixtures = (IList<Fixture>)DataManager.GetFixtures();
            TableView.Source = new FixturesViewControllerSource<Fixtures>(TableView)
            {
                DataSource = Fixtures,
                Text = fixture => fixture.HomeTeamName + " vs " + fixture.AwayTeamName,
                Detail = fixture => "Date: " + fixture.Date + "\tScore: " + fixture.Result.GoalsHomeTeam + " - " + fixture.Result.GoalsAwayTeam
            };
        }
    }
}
