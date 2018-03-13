using System;
using System.Collections.Generic;
using FootballApp.Data;
using Foundation;
using UIKit;

namespace FootballApp.iOS
{
    public class FixturesViewControllerSource<Fixtures> : UITableViewSource
    {
        public readonly string CellStyleName = "FixtureCell";
        IList<Fixture> FixturesList;
        UITableView TableView;

        public IList<Fixture> DataSource
        {
            get
            {
                return FixturesList;
            }
            set
            {
                FixturesList = value;
                TableView.ReloadData();
            }
        }

        public Func<Fixture, string> Text { get; set; }
        public Func<Fixture, string> Detail { get; set; }

        public FixturesViewControllerSource(UITableView tableView)
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

            Fixture item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);
            cell.TextLabel.Lines = 0;
            cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;
            cell.DetailTextLabel.Text = Detail(item);

            return cell;
        }
    }
}
