using Foundation;
using System;
using UIKit;
using FootballApp.Data;
using System.Collections.Generic;

namespace FootballApp.iOS
{
    public partial class LeagueDetailViewController : UITableViewController
    {
        public League League { get; set; }
        ApiDataManager DataManager = new ApiDataManager();
        IList<Team> Teams;

        public LeagueDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = League.Name;
            Response<IEnumerable<Team>> response = await DataManager.GetLeagueTable(League);
            if (response.Success)
            {
                Teams = (IList<Team>)response.Data;
                if(Teams != null)
                {
                    TableView.Source = new LeaguesDetailViewControllerSource<Team>(TableView)
                    {
                        DataSource = Teams,
                        Text = team => team.TeamName,
                        Detail = team => {
                            string position = team.Position != 0 && team.Position != null ? "position: " + team.Position : "";
                            string points = team.Points != 0 && team.Points != null ? "\tpoints: " + team.Points : "";
                            string group = team.Group != null ? "\tgroup: " + team.Group : "";
                            return position + points + group;
                        },
                        Image = team => team.CrestURI
                    };
                }
                else
                {
                    View = NotFoundView.Create("Teams not found");
                }
            }
            else
            {
                View = NotFoundView.Create(response.Message);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (!String.Equals(segue.Identifier, "SettingsSegue"))
            {
                int selectedRow = TableView.IndexPathForSelectedRow.Row;
                var teamDetail = segue.DestinationViewController as TeamDetailViewController;
                Team team = Teams[selectedRow];

                if (teamDetail != null)
                {
                    teamDetail.Team = team;
                }
            }
        }
    }
}