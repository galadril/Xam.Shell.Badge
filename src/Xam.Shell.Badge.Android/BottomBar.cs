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
            System.Diagnostics.Debug.Assert(typeof(CustomShellItemRenderer) != null);
            System.Diagnostics.Debug.Assert(typeof(CustomShellRenderer) != null);
        }

        #endregion
    }
}
