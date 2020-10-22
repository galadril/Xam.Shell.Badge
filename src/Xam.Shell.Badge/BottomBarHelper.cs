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
        /// Badge text
        /// </summary>
        public static readonly BindableProperty BadgeTextProperty =
            BindableProperty.CreateAttached("BadgeText", typeof(string), typeof(BottomBarHelper),
                string.Empty);

        /// <summary>
        /// Badge background color
        /// </summary>
        public static readonly BindableProperty BadgeBackgroundColorProperty =
            BindableProperty.CreateAttached("BadgeBackgroundColor", typeof(Color), typeof(BottomBarHelper),
                Color.Default);

        /// <summary>
        /// Public method to retrieve text value for specific shell tab
        /// </summary>
        /// <param name="target">Shell tab instance</param>
        /// <returns>Text for specific shell tab</returns>
        public static string GetBadgeText(BindableObject target) =>
            (string)target.GetValue(BadgeTextProperty);

        /// <summary>
        /// Public method to set text value for specific shell tab
        /// </summary>
        /// <param name="view">Shell tab instance</param>
        /// <param name="value">Value</param>
        public static void SetBadgeText(BindableObject view, string value) =>
            view.SetValue(BadgeTextProperty, value);

        /// <summary>
        /// Public method to retrieve background color value for specific shell tab
        /// </summary>
        /// <param name="target">Shell tab instance</param>
        /// <returns>Color for specific shell tab</returns>
        public static Color GetBadgeBackgroundColor(BindableObject target) =>
            (Color)target.GetValue(BadgeBackgroundColorProperty);

        /// <summary>
        /// Public method to set background color value for specific shell tab
        /// </summary>
        /// <param name="view">Shell tab instance</param>
        /// <param name="value">Value</param>
        public static void SetBadgeBackgroundColor(BindableObject view, Color value) =>
            view.SetValue(BadgeBackgroundColorProperty, value);
        #endregion
    }
}
