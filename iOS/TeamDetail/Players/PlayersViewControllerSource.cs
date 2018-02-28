using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FootballApp.iOS
{
    public class PlayersViewControllerSource<Player> : UITableViewSource
    {
        public readonly string CellStyleName = "PlayerCell";
        IList<Player> PlayersList;
        UITableView TableView;

        public IList<Player> DataSource
        {
            get
            {
                return PlayersList;
            }
            set
            {
                PlayersList = value;
                TableView.ReloadData();
            }
        }

        public Func<Player, string> Text { get; set; }

        public PlayersViewControllerSource(UITableView tableView)
        {
            TableView = tableView;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return DataSource.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellStyleName);
            if (cell == null)
            {
                cell = new UITableViewCell(
                    UITableViewCellStyle.Subtitle,
                    CellStyleName);
            }

            Player item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);

            return cell;
        }
    }
}
