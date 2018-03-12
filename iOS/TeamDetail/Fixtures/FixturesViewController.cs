using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;

namespace FootballApp.iOS
{
    public class FixturesViewController : UITableViewController
    {
        public Team Team { get; set; }
        IDataManager DataManager = new ApiDataManager();
        IList<Fixture> Fixtures;

        public FixturesViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Response<IEnumerable<Fixture>> response = await DataManager.GetFixtures(Team);
            if(response.Success)
            {
                Fixtures = (IList<Fixture>)response.Data;
                if (Fixtures.Count > 0)
                {
                    TableView.Source = new FixturesViewControllerSource<Fixtures>(TableView)
                    {
                        DataSource = Fixtures,
                        Text = fixture => fixture.HomeTeamName + " vs " + fixture.AwayTeamName,
                        Detail = fixture => "Date: " + fixture.Date + "\tScore: " + fixture.Result.GoalsHomeTeam + " - " + fixture.Result.GoalsAwayTeam
                    };
                }
                else
                {
                    TableView.DataSource = null;
                    TableView.BackgroundView = NotFoundView.Create("Fixtures not found");
                    TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                }
            }
            else
            {
                TableView.DataSource = null;
                TableView.BackgroundView = NotFoundView.Create(response.Message);
                TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            }
        }
    }
}
