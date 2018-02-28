using Foundation;
using System;
using UIKit;
using FootballApp.Data;
using System.Collections.Generic;

namespace FootballApp.iOS
{
    public partial class LeaguesViewController : UITableViewController
    {

        DataManager DataManager = new DataManager();
        IList<League> Leagues;

        public LeaguesViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Leagues = (IList<League>)await DataManager.GetAllLeagues();
            TableView.Source = new LeaguesViewControllerSource<League>(TableView)
            {
                DataSource = Leagues,
                Text = league => league.Caption
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            int selectedRow = TableView.IndexPathForSelectedRow.Row;
            var leagueDetail = segue.DestinationViewController as LeagueDetailViewController;
            if(leagueDetail != null)
            {
                leagueDetail.NavigationItem.Title = Leagues[selectedRow].Name;
                leagueDetail.Id = Leagues[selectedRow].Id;
            }
        }
    }
}