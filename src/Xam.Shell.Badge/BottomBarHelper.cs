using Xamarin.Forms;

namespace Xam.Shell.Badge
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public class BottomBarHelper
    {
        #region Public

        /// <summary>
        /// Set a badge for a bottombar item.
        /// </summary>
        /// <param name="position">The position<see cref="int"/>.</param>
        /// <param name="counter">The counter<see cref="int"/>.</param>
        public void SetBadge(int position, int counter)
        {
            MessagingCenter.Send<BottomBarHelper, int[]>(this, "SetBadge", new int[] { position, counter });
        }

        /// <summary>
        /// Remove a badge for a bottombar item.
        /// </summary>
        /// <param name="position">The position<see cref="int"/>.</param>
        public void RemoveBadge(int position)
        {
            MessagingCenter.Send<BottomBarHelper, int>(this, "RemoveBadge", position);
        }

        #endregion
    }
}
