using Xam.Shell.Badge.iOS.Renderers;

namespace Xam.Shell.Badge.iOS
{
    /// <summary>
    /// Defines the <see cref="BottomBar" />.
    /// </summary>
    public static class BottomBar
    {
        /// <summary>
        /// The Init.
        /// </summary>
        public static void Init()
        {
            System.Diagnostics.Debug.Assert(typeof(BadgeShellItemRenderer) != null);
            System.Diagnostics.Debug.Assert(typeof(BadgeShellRenderer) != null);
        }
    }
}