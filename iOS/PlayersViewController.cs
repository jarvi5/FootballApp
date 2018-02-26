using System;
using System.Collections.Generic;
using FootballApp.Data;
using UIKit;
namespace FootballApp.iOS
{
    public class PlayersViewController : UITableViewController
    {
        public string teamUrl { get; set; }
        DataManager dataManager = new DataManager();
        IList<Player> players;

        public PlayersViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            players = (IList<Player>)await dataManager.GetPlayers(teamUrl);
            TableView.Source = new PlayersViewControllerSource<Player>(TableView)
            {
                DataSource = players,
                Text = player => "" + player.jerseyNumber + "\t" + player.name
            };
        }
    }
}
