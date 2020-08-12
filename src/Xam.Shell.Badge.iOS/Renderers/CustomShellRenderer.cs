using Xam.Shell.Badge.iOS.Renderers;
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
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShellRenderer"/> class.
        /// </summary>
        public CustomShellRenderer() : base()
        {
        }

        #endregion

        #region Protected

        /// <summary>
        /// The CreateShellSectionRenderer.
        /// </summary>
        /// <param name="shellSection">The shellSection<see cref="ShellSection"/>.</param>
        /// <returns>The <see cref="IShellSectionRenderer"/>.</returns>
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

        /// <summary>
        /// The CreateShellItemRenderer.
        /// </summary>
        /// <param name="item">The item<see cref="ShellItem"/>.</param>
        /// <returns>The <see cref="IShellItemRenderer"/>.</returns>
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var renderer = base.CreateShellItemRenderer(item);
            (renderer as ShellItemRenderer).TabBar.Translucent = false;
            return renderer;
        }

        /// <summary>
        /// The CreateTabBarAppearanceTracker.
        /// </summary>
        /// <returns>The <see cref="IShellTabBarAppearanceTracker"/>.</returns>
        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomShellBottomAppearance();
        }

        #endregion
    }
}
