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

        /// <summary>
        /// Set a tiny badge for a bottombar item. A tiny badge is a small filled circle with no number. 
        /// </summary>
        /// <param name="position">The tab position<see cref="int"/>.</param>
        /// <param name="color">The color value of the tiny badge<see cref="Color"/>.</param>
        public void SetTinyBadge(int position, Color color)
        {
            MessagingCenter.Send<BottomBarHelper, int[]>(this, "SetTinyBadge", new int[] { position, (int)(color.R * 255), (int)(color.G * 255), (int)(color.B * 255) });
        }
        #endregion
    }
}
