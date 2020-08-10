using System;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xam.Shell.Badge.Droid.Renderers
{
    internal class CustomShellBottomAppearance : IShellBottomNavViewAppearanceTracker
    {
        private BottomNavigationMenuView _bottomNavigationMenuView;

        public CustomShellBottomAppearance(CustomShellRenderer shellRenderer)
        { }

        public void Dispose()
        { }

        public void ResetAppearance(BottomNavigationView bottomView)
        { }

        /// <summary>
        /// Set appearance
        /// </summary>
        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilitySelected;
            _bottomNavigationMenuView = (BottomNavigationMenuView)bottomView.GetChildAt(0);

            MessagingCenter.Subscribe<BottomBarHelper, int[]>(this, "SetBadge", (sender, values) =>
            {
                CreatePageBadge(values[0], values[1] > 0, values[1], _bottomNavigationMenuView);
            });
        }

        /// <summary>
        /// Create page badge
        /// </summary>
        private void CreatePageBadge(int index, bool ShowBadge, int BadgeCount, BottomNavigationMenuView _bottomNavigationMenuView)
        {
            var itemView = (BottomNavigationItemView)_bottomNavigationMenuView.GetChildAt(index);
            if (ShowBadge && BadgeCount > 0)
            {
                var mtxtnotificationsbadge = itemView.FindViewById<TextView>(Resource.Id.txtbadge);
                if (mtxtnotificationsbadge == null)
                {
                    var vBadge = LayoutInflater.From(CrossCurrentActivity.Current.Activity).Inflate(Resource.Layout.notification_badge, _bottomNavigationMenuView, false);
                    itemView.AddView(vBadge);
                    mtxtnotificationsbadge = itemView.FindViewById<TextView>(Resource.Id.txtbadge);
                }
                mtxtnotificationsbadge.Text = BadgeCount.ToString();
                if (mtxtnotificationsbadge.Text.Length == 1)
                    mtxtnotificationsbadge.SetBackgroundResource(Resource.Drawable.custom_circle_shape);
                else
                    mtxtnotificationsbadge.SetBackgroundResource(Resource.Drawable.custom_rectangle_shape);
            }
            else
            {
                var badgeLayout = itemView.FindViewById<FrameLayout>(Resource.Id.badge);
                if (badgeLayout != null)
                    itemView.RemoveView(badgeLayout);
            }
        }
    }
}