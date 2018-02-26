using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FootballApp.iOS
{
    public class PlayersViewControllerSource<Player> : UITableViewSource
    {
        public readonly string cellStyleName = "PlayerCell";
        IList<Player> dataSource;
        UITableView tableView;

        public IList<Player> DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                tableView.ReloadData();
            }
        }

        public Func<Player, string> Text { get; set; }

        public PlayersViewControllerSource(UITableView tableView)
        {
            this.tableView = tableView;
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
            var cell = tableView.DequeueReusableCell(cellStyleName);
            if (cell == null)
            {
                cell = new UITableViewCell(
                    UITableViewCellStyle.Subtitle,
                    cellStyleName);
            }

            Player item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);

            return cell;
        }
    }
}
