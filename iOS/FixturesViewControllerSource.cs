using System;
using System.Collections.Generic;
using FootballApp.Data;
using Foundation;
using UIKit;

namespace FootballApp.iOS
{
    public class FixturesViewControllerSource<Fixtures> : UITableViewSource
    {
        public readonly string cellStyleName = "FixtureCell";
        IList<Fixture> dataSource;
        UITableView tableView;

        public IList<Fixture> DataSource
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

        public Func<Fixture, string> Text { get; set; }
        public Func<Fixture, string> Detail { get; set; }

        public FixturesViewControllerSource(UITableView tableView)
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

            Fixture item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);
            cell.DetailTextLabel.Text = Detail(item);

            return cell;
        }
    }
}
