using System;
using System.Collections.Generic;
using FootballApp.Data;
using Foundation;
using UIKit;

namespace FootballApp.iOS
{
    public class LeaguesViewControllerSource<League> : UITableViewSource
    {
        public readonly string CellStyleName = "LeagueCell";
        IList<League> LeaguesList;
        UITableView TableView;

        public IList<League> DataSource
        {
            get
            {
                return LeaguesList;
            }
            set
            {
                LeaguesList = value;
                TableView.ReloadData();
            }
        }

        public Func<League, string> Text { get; set; }

        public LeaguesViewControllerSource (UITableView tableView)
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
                    UITableViewCellStyle.Default,
                    CellStyleName);
            }

            League item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);

            return cell;
        }

    }
}
