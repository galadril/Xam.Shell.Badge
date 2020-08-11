using Xam.Shell.Badge.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace Xam.Shell.Badge.iOS.Renderers
{
    /// <summary>
    /// The CustomShellRenderer is necessary in order to replace the ShellItemRenderer with your own.
    /// </summary>
    class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer() : base()
        { }

        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer = base.CreateShellSectionRenderer(shellSection);
            if (renderer != null)
            {
                var a = (renderer as ShellSectionRenderer);
                (renderer as ShellSectionRenderer).NavigationBar.Translucent = false;
            }
            return renderer;
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var renderer = base.CreateShellItemRenderer(item);
            (renderer as ShellItemRenderer).TabBar.Translucent = false;
            return renderer;
        }

        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomShellBottomAppearance();
        }
    }
}