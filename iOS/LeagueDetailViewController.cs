using Foundation;
using System;
using UIKit;
using FootballApp.Data;
using System.Collections.Generic;

namespace FootballApp.iOS
{
    public partial class LeagueDetailViewController : UITableViewController
    {
        public int Id { get; set; }
        DataManager DataManager = new DataManager();
        IList<Team> Teams;

        public LeagueDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Teams = (IList<Team>)await DataManager.GetLeagueTable(Id);
            TableView.Source = new LeaguesDetailViewControllerSource<Team>(TableView)
            {
                DataSource = Teams,
                Text = team => team.TeamName,
                Detail = team => "position: " + team.Position + "\tpoints: " + team.Points,
                Image = team => team.CrestURI
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            int selectedRow = TableView.IndexPathForSelectedRow.Row;
            var teamDetail = segue.DestinationViewController as TeamDetailViewController;
            Team team = Teams[selectedRow];

            if (teamDetail != null)
            {
                teamDetail.NavigationItem.Title = team.TeamName;
                teamDetail.TeamUrl = team.Links.Team.Href;
            }
        }
    }
}