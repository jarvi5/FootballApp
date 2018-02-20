using System;
using System.Collections.Generic;
using FootballApp.Data;
using Foundation;
using UIKit;

namespace FootballApp.iOS
{
    public class LeaguesViewControllerSource<T> : UITableViewSource
    {
        public readonly string cellStyleName = "LeagueCell";

        IList<League> dataSource;
        UITableView tableView;

        public IList<League> DataSource
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

        public Func<T, string> Text { get; set; }

        public LeaguesViewControllerSource (UITableView tableView)
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
                    UITableViewCellStyle.Default,
                    cellStyleName);
            }

            League item = DataSource[indexPath.Row];

            cell.TextLabel.Text = item.caption;

            return cell;
        }

    }
}
