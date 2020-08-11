using System;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Xam.Shell.Badge.iOS.Renderers
{
    public class CustomShellBottomAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        { }

        public void ResetAppearance(UITabBarController controller)
        {
        }

        public async void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
        }

        public void UpdateLayout(UITabBarController controller)
        {
            MessagingCenter.Subscribe<BottomBarHelper, int[]>(this, "SetBadge", (sender, values) =>
            {
                if (controller?.TabBar?.Items != null && controller.TabBar.Items.Any())
                    controller.TabBar.Items[values[0]].BadgeValue = values[1].ToString();
            });
        }
    }
}