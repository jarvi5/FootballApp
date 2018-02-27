using Foundation;
using System;
using UIKit;

namespace FootballApp.iOS
{
    public partial class TeamDetailViewController : UITabBarController
    {
        public string teamUrl { get; set; }
        PlayersViewController playersViewController;
        FixturesViewController fixturesViewController;

        public TeamDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            playersViewController = new PlayersViewController();
            playersViewController.Title = "Players";
            playersViewController.teamUrl = teamUrl;

            fixturesViewController = new FixturesViewController();
            fixturesViewController.Title = "Fixtures";
            fixturesViewController.teamUrl = teamUrl;

            ViewControllers = new UIViewController[] {
                playersViewController,
                fixturesViewController
            };
        }
    }
}