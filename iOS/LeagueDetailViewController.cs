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
        IList<Team> Teams;

        public LeagueDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Teams = (IList<Team>)await dataManager.GetLeagueTable(id);
            TableView.Source = new LeaguesDetailViewControllerSource<Team>(TableView)
            {
                DataSource = Teams,
                Text = team => team.teamName,
                Detail = team => "position: " + team.position + "\tpoints: " + team.points,
                Image = team => team.crestURI
            };
        }
    }
}