using Foundation;
using System;
using UIKit;
using FootballApp.Data;
using System.Collections.Generic;

namespace FootballApp.iOS
{
    public partial class LeaguesViewController : UITableViewController
    {

        DataManager dataManager = new DataManager();
        IList<League> Leagues;

        public LeaguesViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Leagues = (IList<League>)await dataManager.GetAllLeagues();
            TableView.Source = new LeaguesViewControllerSource<League>(TableView)
            {
                DataSource = Leagues,
                Text = league => league.caption
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            int selectedRow = TableView.IndexPathForSelectedRow.Row;
            var leagueDetail = segue.DestinationViewController as LeagueDetailViewController;
            if(leagueDetail != null)
            {
                leagueDetail.NavigationItem.Title = Leagues[selectedRow].league;
                leagueDetail.id = Leagues[selectedRow].id;
            }
        }
    }
}