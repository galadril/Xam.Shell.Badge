using Xamarin.Forms;

namespace Xam.Shell.Badge
{
    /// <summary>
    /// Helper class
    /// </summary>
    public class BottomBarHelper
    {
        /// <summary>
        /// Set a badge for a bottombar item
        /// </summary>
        public void SetBadge(int position, int counter)
        {
            MessagingCenter.Send<BottomBarHelper, int[]>(this, "SetBadge", new int[] {position, counter });
        }
    }
}
