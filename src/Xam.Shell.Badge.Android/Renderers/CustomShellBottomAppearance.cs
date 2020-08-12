using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xam.Shell.Badge.Droid.Renderers
{
    /// <summary>
    /// Defines the <see cref="CustomShellBottomAppearance" />.
    /// </summary>
    internal class CustomShellBottomAppearance : IShellBottomNavViewAppearanceTracker
    {
        #region Variables

        /// <summary>
        /// Defines the _bottomNavigationMenuView.
        /// </summary>
        private BottomNavigationMenuView _bottomNavigationMenuView;

        #endregion

        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShellBottomAppearance"/> class.
        /// </summary>
        /// <param name="shellRenderer">The shellRenderer<see cref="CustomShellRenderer"/>.</param>
        public CustomShellBottomAppearance(CustomShellRenderer shellRenderer)
        {
        }

        #endregion

        #region Public

        /// <summary>
        /// The Dispose.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// The ResetAppearance.
        /// </summary>
        /// <param name="bottomView">The bottomView<see cref="BottomNavigationView"/>.</param>
        public void ResetAppearance(BottomNavigationView bottomView)
        {
            Init(bottomView);
        }

        /// <summary>
        /// The SetAppearance.
        /// </summary>
        /// <param name="bottomView">The bottomView<see cref="BottomNavigationView"/>.</param>
        /// <param name="appearance">The appearance<see cref="IShellAppearanceElement"/>.</param>
        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
        }

        /// <summary>
        /// The Init.
        /// </summary>
        /// <param name="bottomView">The bottomView<see cref="BottomNavigationView"/>.</param>
        public void Init(BottomNavigationView bottomView)
        {
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilitySelected;
            if (_bottomNavigationMenuView == null)
                _bottomNavigationMenuView = (BottomNavigationMenuView)bottomView.GetChildAt(0);
            MessagingCenter.Subscribe<BottomBarHelper, int[]>(this, "SetBadge", (sender, values) =>
            {
                CreatePageBadge(values[0], values[1] > 0, values[1], _bottomNavigationMenuView);
            });
            MessagingCenter.Subscribe<BottomBarHelper, int>(this, "RemoveBadge", (sender, value) =>
            {
                CreatePageBadge(value, false, 0, _bottomNavigationMenuView);
            });
        }

        #endregion

        #region Private

        /// <summary>
        /// The CreatePageBadge.
        /// </summary>
        /// <param name="index">The index<see cref="int"/>.</param>
        /// <param name="ShowBadge">The ShowBadge<see cref="bool"/>.</param>
        /// <param name="BadgeCount">The BadgeCount<see cref="int"/>.</param>
        /// <param name="_bottomNavigationMenuView">The _bottomNavigationMenuView<see cref="BottomNavigationMenuView"/>.</param>
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

        #endregion
    }
}
