using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xam.Shell.Badge.Droid.Renderers
{
    /// <summary>
    /// Defines the <see cref="CustomShellItemRenderer" />.
    /// </summary>
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShellItemRenderer"/> class.
        /// </summary>
        /// <param name="shellContext">The shellContext<see cref="IShellContext"/>.</param>
        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        #endregion

        #region Protected

        /// <summary>
        /// The OnTabReselected.
        /// </summary>
        /// <param name="shellSection">The shellSection<see cref="ShellSection"/>.</param>
        protected override void OnTabReselected(ShellSection shellSection)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await shellSection?.Navigation.PopToRootAsync();
            });
        }

        #endregion
    }
}
