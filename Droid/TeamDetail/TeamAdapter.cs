using Android.Support.V4.App;

namespace FootballApp.Droid
{
    class TeamAdapter : FragmentPagerAdapter
    {
        Fragment[] Fragments;
        public TeamAdapter(FragmentManager fragmnetManager, Fragment[] fragments)
            : base(fragmnetManager)
        {
            Fragments = fragments;
        }

        public override int Count
        {
            get { return Fragments.Length; }
        }

        public override Fragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            if (position == 0)
            {
                return new Java.Lang.String("Players");
            }
            return new Java.Lang.String("Fixtures");
        }
    }
}