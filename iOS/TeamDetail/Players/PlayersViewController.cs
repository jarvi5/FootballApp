using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;
namespace FootballApp.iOS
{
    public class PlayersViewController : UITableViewController
    {
        public string TeamUrl { get; set; }
        ApiDataManager DataManager = new ApiDataManager();
        IList<Player> Players;

        public PlayersViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await DataManager.LoadData(TeamUrl + "/players");
            Players = (IList<Player>)DataManager.GetPlayers();
            TableView.Source = new PlayersViewControllerSource<Player>(TableView)
            {
                DataSource = Players,
                Text = player => "" + player.JerseyNumber + "\t" + player.Name
            };
        }
    }
}
