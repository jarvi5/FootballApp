using System.Collections.Generic;
using FootballApp.Data;
using UIKit;
namespace FootballApp.iOS
{
    public class PlayersViewController : UITableViewController
    {
        public Team Team { get; set; }
        IDataManager DataManager = new ApiDataManager();
        IList<Player> Players;

        public PlayersViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Response<IEnumerable<Player>> response = await DataManager.GetPlayers(Team);
            if (response.Success)
            {
                Players = (IList<Player>)response.Data;
                if (Players.Count > 0)
                {
                    TableView.Source = new PlayersViewControllerSource<Player>(TableView)
                    {
                        DataSource = Players,
                        Text = player => "" + player.JerseyNumber + "\t" + player.Name
                    };
                }
                else
                {
                    TableView.DataSource = null;
                    TableView.BackgroundView = NotFoundView.Create("Players not found");
                    TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                }
            }
            else 
            {
                TableView.DataSource = null;
                TableView.BackgroundView = NotFoundView.Create(response.Message);
                TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            }
        }
    }
}
