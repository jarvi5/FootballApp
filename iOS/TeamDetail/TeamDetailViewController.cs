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