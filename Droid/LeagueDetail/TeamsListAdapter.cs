using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using FFImageLoading.Views;
using FootballApp.Data;

namespace FootballApp.Droid
{
    public class TeamsListAdapter : BaseAdapter<Team>
    {
        IList<Team> Teams;
        Activity Context;

        public TeamsListAdapter(Activity context, IList<Team> teams)
        {
            Teams = teams;
            Context = context;
        }

        public override Team this[int position]
        {
            get { return Teams[position]; }
        }

        public override int Count
        {
            get { return Teams.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Team item = Teams[position];
            View view = convertView;
            if (view == null)
                view = Context.LayoutInflater.Inflate(Resource.Layout.TeamCellView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.TeamName;
            string teamPosition = item.Position != 0 && item.Position != null ? "position: " + item.Position : "";
            string points = item.Points != 0 && item.Points != null ? "\tpoints: " + item.Points : "";
            string group = item.Group != null ? "\tgroup: " + item.Group : "";
            view.FindViewById<TextView>(Resource.Id.Text2).Text = teamPosition + points + group;
            ImageViewAsync image = view.FindViewById<ImageViewAsync>(Resource.Id.Image);
            if (!string.IsNullOrEmpty(item.CrestURI))
            {
                ImageService.Instance.LoadUrl(item.CrestURI)
                            .WithCustomDataResolver(new SvgDataResolver(200, 0, true))
                            .WithCustomLoadingPlaceholderDataResolver(new SvgDataResolver(200, 0, true))
                            .Error(exception =>
                            {
                                ImageService.Instance.LoadUrl(item.CrestURI)
                                            .Into(image);
                            })
                            .Into(image);
            }
            return view;
        }
    }
}
