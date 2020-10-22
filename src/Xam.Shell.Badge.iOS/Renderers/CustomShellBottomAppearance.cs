using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Xam.Shell.Badge.iOS.Renderers
{
    /// <summary>
    /// Defines the <see cref="CustomShellBottomAppearance" />.
    /// </summary>
    public class CustomShellBottomAppearance : IShellTabBarAppearanceTracker
    {
        #region Variables

        private UIColor _defaultBarTint;
        private UIColor _defaultTint;
        private UIColor _defaultUnselectedTint;

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
        /// <param name="controller">The controller<see cref="UITabBarController"/>.</param>
        public void ResetAppearance(UITabBarController controller)
        {
            if (_defaultTint == null)
                return;

            var tabBar = controller.TabBar;
            tabBar.BarTintColor = _defaultBarTint;
            tabBar.TintColor = _defaultTint;
            tabBar.UnselectedItemTintColor = _defaultUnselectedTint;
        }

        /// <summary>
        /// The SetAppearance.
        /// </summary>
        /// <param name="controller">The controller<see cref="UITabBarController"/>.</param>
        /// <param name="appearance">The appearance<see cref="ShellAppearance"/>.</param>
        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            IShellAppearanceElement appearanceElement = appearance;
            var backgroundColor = appearanceElement.EffectiveTabBarBackgroundColor;
            var unselectedColor = appearanceElement.EffectiveTabBarUnselectedColor;
            var titleColor = appearanceElement.EffectiveTabBarTitleColor;

            var tabBar = controller.TabBar;
            var operatingSystemSupportsUnselectedTint = UIDevice.CurrentDevice.CheckSystemVersion(10, 0);

            if (_defaultTint == null)
            {
                _defaultBarTint = tabBar.BarTintColor;
                _defaultTint = tabBar.TintColor;

                if (operatingSystemSupportsUnselectedTint)
                {
                    _defaultUnselectedTint = tabBar.UnselectedItemTintColor;
                }
            }

            if (!backgroundColor.IsDefault)
                tabBar.BarTintColor = backgroundColor.ToUIColor();
            if (!titleColor.IsDefault)
                tabBar.TintColor = titleColor.ToUIColor();

            if (operatingSystemSupportsUnselectedTint)
            {
                if (!unselectedColor.IsDefault)
                    tabBar.UnselectedItemTintColor = unselectedColor.ToUIColor();
            }

            tabBar.Translucent = false;
        }

        /// <summary>
        /// The UpdateLayout.
        /// </summary>
        /// <param name="controller">The controller<see cref="UITabBarController"/>.</param>
        public void UpdateLayout(UITabBarController controller) { }

        #endregion
    }
}
