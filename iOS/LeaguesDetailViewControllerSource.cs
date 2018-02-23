using System;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using SDWebImage;
using UIKit;

namespace FootballApp.iOS
{
    public class LeaguesDetailViewControllerSource<Team> : UITableViewSource
    {
        public readonly string cellStyleName = "TeamCell";

        IList<Team> dataSource;
        UITableView tableView;

        public IList<Team> DataSource
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

        public Func<Team, string> Text { get; set; }
        public Func<Team, string> Detail { get; set; }
        public Func<Team, string> Image { get; set; }

        public LeaguesDetailViewControllerSource(UITableView tableView)
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

            Team item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);
            cell.DetailTextLabel.Text = Detail(item);
            if ((cell != null) && !string.IsNullOrEmpty(Image(item)))
            {
                Uri uri = new Uri(Image(item));
                IdnMapping idn = new IdnMapping();
                cell.ImageView.SetImage(new NSUrl(uri.Scheme, idn.GetAscii(uri.DnsSafeHost), uri.PathAndQuery));
            }
            cell.ImageView.Frame = new CoreGraphics.CGRect(0, 0, 44, 44);
            return cell;
        }
    }
}
