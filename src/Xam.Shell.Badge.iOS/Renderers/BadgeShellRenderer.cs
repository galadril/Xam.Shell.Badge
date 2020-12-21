using Xam.Shell.Badge.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(Shell), typeof(BadgeShellRenderer))]
namespace Xam.Shell.Badge.iOS.Renderers
{
    /// <summary>
    /// The BadgeShellRenderer is necessary in order to replace the ShellItemRenderer with your own.
    /// </summary>
    public class BadgeShellRenderer : ShellRenderer
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeShellRenderer"/> class.
        /// </summary>
        public BadgeShellRenderer() : base()
        {
        }

        #endregion

        #region Protected

        /// <summary>
        /// The CreateShellItemRenderer.
        /// </summary>
        /// <param name="item">The item<see cref="ShellItem"/>.</param>
        /// <returns>The <see cref="IShellItemRenderer"/>.</returns>
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item) =>
            new BadgeShellItemRenderer(this) { ShellItem = item };

        #endregion
    }
}
