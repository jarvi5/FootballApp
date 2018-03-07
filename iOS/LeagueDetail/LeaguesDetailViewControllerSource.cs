using System;
using System.Collections.Generic;
using System.Globalization;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using Foundation;
using SDWebImage;
using UIKit;

namespace FootballApp.iOS
{
    public class LeaguesDetailViewControllerSource<Team> : UITableViewSource
    {
        public readonly string CellStyleName = "TeamCell";
        IList<Team> TeamsList;
        UITableView TableView;

        public IList<Team> DataSource
        {
            get
            {
                return TeamsList;
            }
            set
            {
                TeamsList = value;
                TableView.ReloadData();
            }
        }

        public Func<Team, string> Text { get; set; }
        public Func<Team, string> Detail { get; set; }
        public Func<Team, string> Image { get; set; }

        public LeaguesDetailViewControllerSource(UITableView tableView)
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

            Team item = DataSource[indexPath.Row];

            cell.TextLabel.Text = Text(item);
            cell.DetailTextLabel.Text = Detail(item);
            string imageUrl = Image(item);
            UIImageView image = cell.ImageView;
            if (!string.IsNullOrEmpty(imageUrl))
            {
                ImageService.Instance.LoadUrl(imageUrl)
                            .WithCustomDataResolver(new SvgDataResolver(200, 0, true))
                            .WithCustomLoadingPlaceholderDataResolver(new SvgDataResolver(200, 0, true))
                            .Error(exception =>
                            {
                                ImageService.Instance.LoadUrl(imageUrl)
                                        .Into(image);
                            })
                            .Into(image);
            }
            return cell;
        }
    }
}
