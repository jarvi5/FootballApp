using Foundation;
using System;
using UIKit;

namespace FootballApp.iOS
{
    public partial class TeamDetailViewController : UITabBarController
    {
        public string TeamUrl { get; set; }
        PlayersViewController PlayersViewController;
        FixturesViewController FixturesViewController;

        public TeamDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            PlayersViewController = new PlayersViewController();
            PlayersViewController.Title = "Players";
            PlayersViewController.TeamUrl = TeamUrl;

            FixturesViewController = new FixturesViewController();
            FixturesViewController.Title = "Fixtures";
            FixturesViewController.TeamUrl = TeamUrl;

            ViewControllers = new UIViewController[] {
                PlayersViewController,
                FixturesViewController
            };
        }
    }
}