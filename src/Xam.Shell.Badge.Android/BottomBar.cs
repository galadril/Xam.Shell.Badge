using Xam.Shell.Badge.Droid.Renderers;

namespace Xam.Shell.Badge.Droid
{
    /// <summary>
    /// Defines the <see cref="BottomBar" />.
    /// </summary>
    public static class BottomBar
    {
        #region Public

        /// <summary>
        /// The Init.
        /// </summary>
        public static void Init()
        {
            System.Diagnostics.Debug.Assert(typeof(BadgeShellItemRenderer) != null);
            System.Diagnostics.Debug.Assert(typeof(BadgeShellRenderer) != null);
        }

        #endregion
    }
}