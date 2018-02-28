using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;
namespace FootballApp.iOS
{
    public class PlayersViewController : UITableViewController
    {
        public string TeamUrl { get; set; }
        DataManager DataManager = new DataManager();
        IList<Player> Players;

        public PlayersViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Players = (IList<Player>)await DataManager.GetPlayers(TeamUrl);
            TableView.Source = new PlayersViewControllerSource<Player>(TableView)
            {
                DataSource = Players,
                Text = player => "" + player.JerseyNumber + "\t" + player.Name
            };
        }
    }
}
