using Xam.Shell.Badge.iOS.Renderers;

namespace Xam.Shell.Badge.iOS
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
            System.Diagnostics.Debug.Assert(typeof(CustomShellBottomAppearance) != null);
            System.Diagnostics.Debug.Assert(typeof(CustomShellRenderer) != null);
        }

        #endregion
    }
}
