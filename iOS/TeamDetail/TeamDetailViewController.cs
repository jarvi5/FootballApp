using CoreGraphics;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using FootballApp.Data;
using System;
using UIKit;

namespace FootballApp.iOS
{
    public partial class TeamDetailViewController : UITabBarController
    {
        public Team Team { get; set; }
        PlayersViewController PlayersViewController;
        FixturesViewController FixturesViewController;

        public TeamDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIImageView image = new UIImageView
            {
                Frame = new CGRect(0, 0, 40, 40)
            };
            if (!string.IsNullOrEmpty(Team.CrestURI))
            {
                ImageService.Instance.LoadUrl(Team.CrestURI)
                            .WithCustomDataResolver(new SvgDataResolver(200, 0, true))
                            .WithCustomLoadingPlaceholderDataResolver(new SvgDataResolver(200, 0, true))
                            .Error(exception =>
                            {
                                ImageService.Instance.LoadUrl(Team.CrestURI)
                                        .Into(image);
                            })
                            .Into(image);
            }

            NavigationItem.TitleView = new UIView
            {
                Frame = new CGRect(0, 0, View.Bounds.Size.Width, 40)
            };
            NavigationItem.TitleView.Add(image);
            NavigationItem.TitleView.Add(new UILabel
            {
                Frame = new CGRect(50, 0, View.Bounds.Size.Width, 40),
                Text = Team.TeamName
            });

            PlayersViewController = new PlayersViewController();
            PlayersViewController.Title = "Players";
            PlayersViewController.Team = Team;

            FixturesViewController = new FixturesViewController();
            FixturesViewController.Title = "Fixtures";
            FixturesViewController.Team = Team;

            ViewControllers = new UIViewController[] {
                PlayersViewController,
                FixturesViewController
            };
        }

	}
}