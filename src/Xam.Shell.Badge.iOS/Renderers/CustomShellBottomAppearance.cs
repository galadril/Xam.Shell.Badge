using System.Linq;
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
        }

        /// <summary>
        /// The SetAppearance.
        /// </summary>
        /// <param name="controller">The controller<see cref="UITabBarController"/>.</param>
        /// <param name="appearance">The appearance<see cref="ShellAppearance"/>.</param>
        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
        }

        /// <summary>
        /// The UpdateLayout.
        /// </summary>
        /// <param name="controller">The controller<see cref="UITabBarController"/>.</param>
        public void UpdateLayout(UITabBarController controller)
        {
            MessagingCenter.Subscribe<BottomBarHelper, int[]>(this, "SetBadge", (sender, values) =>
            {
                if (controller?.TabBar?.Items != null && controller.TabBar.Items.Any())
                    controller.TabBar.Items[values[0]].BadgeValue = values[1].ToString();
            });
            MessagingCenter.Subscribe<BottomBarHelper, int>(this, "RemoveBadge", (sender, value) =>
            {
                if (controller?.TabBar?.Items != null && controller.TabBar.Items.Any())
                    controller.TabBar.Items[value].BadgeValue = null;
            });
        }

        #endregion
    }
}
