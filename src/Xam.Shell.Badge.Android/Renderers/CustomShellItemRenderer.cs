using Android.OS;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Plugin.CurrentActivity;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xam.Shell.Badge.Droid.Renderers
{
    /// <summary>
    /// Defines the <see cref="CustomShellItemRenderer" />.
    /// </summary>
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        #region Variables

        private BottomNavigationView _bottomNavigationView;

        #endregion

        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShellItemRenderer"/> class.
        /// </summary>
        /// <param name="shellContext">The shellContext<see cref="IShellContext"/>.</param>
        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext) { }

        #endregion

        #region Public

        /// <summary>
        /// View init.
        /// </summary>
        /// <param name="inflater"></param>
        /// <param name="container"></param>
        /// <param name="savedInstanceState"></param>
        /// <returns></returns>
        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
            _bottomNavigationView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);

            SetupBadges();

            return outerlayout;
        }

        #endregion

        #region Protected

        /// <summary>
        /// The OnTabReselected.
        /// </summary>
        /// <param name="shellSection">The shellSection<see cref="ShellSection"/>.</param>
        protected override void OnTabReselected(ShellSection shellSection)
        {
            if (null != shellSection)
                Device.InvokeOnMainThreadAsync(
                    shellSection.Navigation.PopToRootAsync);
        }

        /// <summary>
        /// Occures when property changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShellSectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnShellSectionPropertyChanged(sender, e);

            if (e.PropertyName == BottomBarHelper.BadgeTextProperty.PropertyName)
            {
                var item = (ShellSection)sender;
                var index = ShellItem.Items.IndexOf(item);
                var text = BottomBarHelper.GetBadgeText(item);
                var bg = BottomBarHelper.GetBadgeBackgroundColor(item);
                if (!string.IsNullOrEmpty(text))
                    ApplyBadge(index, text, bg);
            }
        }

        #endregion

        #region Private

        private void SetupBadges()
        {
            for (int i = 0; i < ShellItem.Items.Count; i++)
            {
                var item = ShellItem.Items.ElementAtOrDefault(i);
                var text = BottomBarHelper.GetBadgeText(item);
                var bg = BottomBarHelper.GetBadgeBackgroundColor(item);
                ApplyBadge(i, text, bg);
            }
        }

        private void ApplyBadge(int index, string text, Color bg)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var badgeValue = Convert.ToInt32(text);
                if (badgeValue > 0)
                {
                    CreatePageBadge(
                       index: index,
                       showBadge: true,
                       badgeCount: badgeValue,
                       bg: bg,
                       bottomNavigationMenuView: (BottomNavigationMenuView)_bottomNavigationView.GetChildAt(0));
                }
                else
                {
                    CreatePageTinyBadge(
                        index: index,
                        showBadge: true,
                        bg: bg,
                        bottomNavigationMenuView: (BottomNavigationMenuView)_bottomNavigationView.GetChildAt(0));
                }
            }
            else CreatePageBadge(
                index: index,
                showBadge: false,
                badgeCount: 0,
                bg: bg,
                bottomNavigationMenuView: (BottomNavigationMenuView)_bottomNavigationView.GetChildAt(0));
        }

        /// <summary>
        /// The CreatePageBadge.
        /// </summary>
        /// <param name="index">The index<see cref="int"/>.</param>
        /// <param name="showBadge">The ShowBadge<see cref="bool"/>.</param>
        /// <param name="badgeCount">The BadgeCount<see cref="int"/>.</param>
        /// <param name="bg">The BackgroundColor<see cref="int"/>.</param>
        /// <param name="bottomNavigationMenuView">The _bottomNavigationMenuView<see cref="BottomNavigationMenuView"/>.</param>
        private void CreatePageBadge(int index, bool showBadge, int badgeCount, Color bg, BottomNavigationMenuView bottomNavigationMenuView)
        {
            var itemView = (BottomNavigationItemView)bottomNavigationMenuView.GetChildAt(index);
            if (showBadge && badgeCount > 0)
            {
                var mtxtnotificationsbadge = itemView.FindViewById<TextView>(Resource.Id.txtbadge);
                if (mtxtnotificationsbadge == null)
                {
                    var vBadge = LayoutInflater.From(CrossCurrentActivity.Current.Activity).Inflate(Resource.Layout.notification_badge, bottomNavigationMenuView, false);
                    itemView.AddView(vBadge);
                    mtxtnotificationsbadge = itemView.FindViewById<TextView>(Resource.Id.txtbadge);
                }
                mtxtnotificationsbadge.Text = badgeCount.ToString();
                mtxtnotificationsbadge.SetBackgroundColor(bg.ToAndroid());
                mtxtnotificationsbadge.SetTextColor(Android.Graphics.Color.White);
            }
            else
            {
                var badgeLayout = itemView.FindViewById<FrameLayout>(Resource.Id.badge);
                if (badgeLayout != null)
                    itemView.RemoveView(badgeLayout);
            }
        }

        /* TinyBadge is simply a styled bullet with on transparent background
         */
        private void CreatePageTinyBadge(int index, bool showBadge, Color bg, BottomNavigationMenuView bottomNavigationMenuView)
        {
            var itemView = (BottomNavigationItemView)bottomNavigationMenuView.GetChildAt(index);
            if (showBadge)
            {
                var mtxtnotificationsbadge = itemView.FindViewById<TextView>(Resource.Id.txtbadge);
                if (mtxtnotificationsbadge == null)
                {
                    var vBadge = LayoutInflater.From(CrossCurrentActivity.Current.Activity).Inflate(Resource.Layout.notification_badge, bottomNavigationMenuView, false);
                    itemView.AddView(vBadge);
                    mtxtnotificationsbadge = itemView.FindViewById<TextView>(Resource.Id.txtbadge);
                }
                mtxtnotificationsbadge.Text = "●";
                mtxtnotificationsbadge.TextSize = 24;
                mtxtnotificationsbadge.SetBackgroundColor(bg.ToAndroid());
                mtxtnotificationsbadge.SetTextColor(Android.Graphics.Color.White);
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