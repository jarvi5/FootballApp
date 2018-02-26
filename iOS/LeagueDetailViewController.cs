using Foundation;
using System;
using UIKit;
using FootballApp.Data;
using System.Collections.Generic;

namespace FootballApp.iOS
{
    public partial class LeagueDetailViewController : UITableViewController
    {
        public int id { get; set; }
        DataManager dataManager = new DataManager();
        IList<Team> teams;

        public LeagueDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            teams = (IList<Team>)await dataManager.GetLeagueTable(id);
            TableView.Source = new LeaguesDetailViewControllerSource<Team>(TableView)
            {
                DataSource = teams,
                Text = team => team.teamName,
                Detail = team => "position: " + team.position + "\tpoints: " + team.points,
                Image = team => team.crestURI
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            int selectedRow = TableView.IndexPathForSelectedRow.Row;
            var teamDetail = segue.DestinationViewController as TeamDetailViewController;
            Team team = teams[selectedRow];

            if (teamDetail != null)
            {
                teamDetail.NavigationItem.Title = team.teamName;
                teamDetail.teamUrl = team._links.team.href;
            }
        }
    }
}