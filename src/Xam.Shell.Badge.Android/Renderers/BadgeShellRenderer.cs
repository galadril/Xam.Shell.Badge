using Android.Content;
using Xam.Shell.Badge.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(BadgeShellRenderer))]
namespace Xam.Shell.Badge.Droid.Renderers
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
        /// <param name="context">The context<see cref="Context"/>.</param>
        public BadgeShellRenderer(Context context) : base(context) { }

        #endregion

        #region Protected

        /// <summary>
        /// The CreateShellItemRenderer.
        /// </summary>
        /// <param name="shellItem">The shellItem<see cref="ShellItem"/>.</param>
        /// <returns>The <see cref="IShellItemRenderer"/>.</returns>
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem) =>
            new BadgeShellItemRenderer(this);

        #endregion
    }
}