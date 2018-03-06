using Foundation;
using System;
using UIKit;
using FootballApp.Data;
using System.Collections.Generic;

namespace FootballApp.iOS
{
    public partial class LeaguesViewController : UITableViewController
    {

        ApiDataManager DataManager = new ApiDataManager();
        IList<League> Leagues;

        public LeaguesViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            await DataManager.LoadData("http://www.football-data.org/v1/competitions/?season=2017");
            Leagues = (IList<League>)DataManager.GetAllLeagues();
            TableView.Source = new LeaguesViewControllerSource<League>(TableView)
            {
                DataSource = Leagues,
                Text = league => league.Caption
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if(!String.Equals(segue.Identifier, "SettingsSegue"))
            {
                int selectedRow = TableView.IndexPathForSelectedRow.Row;
                var leagueDetail = segue.DestinationViewController as LeagueDetailViewController;
                if (leagueDetail != null)
                {
                    leagueDetail.NavigationItem.Title = Leagues[selectedRow].Name;
                    leagueDetail.Id = Leagues[selectedRow].Id;
                }
            }
        }
    }
}