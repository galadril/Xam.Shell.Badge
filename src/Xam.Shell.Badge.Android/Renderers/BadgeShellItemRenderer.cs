using Android.OS;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using System.ComponentModel;
using System.Linq;
using Xam.Shell.Badge.Droid.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xam.Shell.Badge.Droid.Renderers
{
    /// <summary>
    /// Defines the <see cref="BadgeShellItemRenderer" />.
    /// </summary>
    public class BadgeShellItemRenderer : ShellItemRenderer
    {
        #region Variables

        /// <summary>
        /// Defines the _bottomNavigationView.
        /// </summary>
        private BottomNavigationView _bottomNavigationView;

        #endregion

        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeShellItemRenderer"/> class.
        /// </summary>
        /// <param name="shellContext">The shellContext<see cref="IShellContext"/>.</param>
        public BadgeShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        #endregion

        #region Public

        /// <summary>
        /// View init.
        /// </summary>
        /// <param name="inflater">.</param>
        /// <param name="container">.</param>
        /// <param name="savedInstanceState">.</param>
        /// <returns>.</returns>
        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
            _bottomNavigationView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);

            SetupBadges();

            return outerlayout;
        }

        #endregion

        #region Private

        /// <summary>
        /// The SetupBadges.
        /// </summary>
        private void SetupBadges()
        {
            for (int i = 0; i < ShellItem.Items.Count; i++)
            {
                var item = ShellItem.Items.ElementAtOrDefault(i);
                var text = Badge.GetText(item);
                var textColor = Badge.GetTextColor(item);
                var bg = Badge.GetBackgroundColor(item);
                ApplyBadge(text, bg, i, textColor);
            }
        }

        /// <summary>
        /// The ApplyBadge.
        /// </summary>
        /// <param name="badgeText">The badgeText<see cref="string"/>.</param>
        /// <param name="badgeBg">The badgeBg<see cref="Color"/>.</param>
        /// <param name="itemId">The itemId<see cref="int"/>.</param>
        /// <param name="textColor">The textColor<see cref="Color"/>.</param>
        private void ApplyBadge(string badgeText,
            Color badgeBg, int itemId, Color textColor)
        {
            using BottomNavigationMenuView bottomNavigationMenuView =
                (BottomNavigationMenuView)_bottomNavigationView.GetChildAt(0);
            var itemView = bottomNavigationMenuView
                .FindViewById<BottomNavigationItemView>(itemId);
            if (string.IsNullOrEmpty(badgeText))
                itemView.ApplyBadge(badgeBg, "", textColor);
            else
            {
                int.TryParse(badgeText, out var badgeNumber);
                if (badgeNumber != 0)
                    itemView.ApplyBadge(badgeBg, badgeText, textColor);
                else itemView.ApplyTinyBadge(textColor);
            }
        }

        #endregion

        #region Protected

        /// <summary>
        /// The on tab reselected method.
        /// </summary>
        /// <param name="shellSection">The shellSection<see cref="ShellSection"/>.</param>
        protected override void OnTabReselected(ShellSection shellSection)
        {
            if (null != shellSection)
                Device.InvokeOnMainThreadAsync(
                    shellSection.Navigation.PopToRootAsync);
        }

        /// <summary>
        /// Occures when property changes.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        protected override void OnShellSectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnShellSectionPropertyChanged(sender, e);

            if (e.PropertyName == Badge.TextProperty.PropertyName ||
                e.PropertyName == Badge.TextColorProperty.PropertyName ||
                e.PropertyName == Badge.BackgroundColorProperty.PropertyName)
            {
                var item = (ShellSection)sender;
                var index = ShellItem.Items.IndexOf(item);
                var text = Badge.GetText(item);
                var textColor = Badge.GetTextColor(item);
                var bg = Badge.GetBackgroundColor(item);
                ApplyBadge(text, bg, index, textColor);
            }
        }

        #endregion
    }
}
