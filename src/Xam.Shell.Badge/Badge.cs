using Xamarin.Forms;

namespace Xam.Shell.Badge
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public class Badge
    {
        #region Variables

        /// <summary>
        /// Text.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.CreateAttached("Text", typeof(string), typeof(Badge),
                string.Empty);

        /// <summary>
        /// Text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.CreateAttached("TextColor", typeof(Color), typeof(Badge),
                Color.White);

        /// <summary>
        /// Background color.
        /// </summary>
        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.CreateAttached("BackgroundColor", typeof(Color), typeof(Badge),
                Color.Default);

        #endregion

        #region Public

        /// <summary>
        /// Public method to retrieve text value for specific shell tab.
        /// </summary>
        /// <param name="target">Shell tab instance.</param>
        /// <returns>Text for specific shell tab.</returns>
        public static string GetText(BindableObject target) =>
            (string)target.GetValue(TextProperty);

        /// <summary>
        /// Public method to set text value for specific shell tab.
        /// </summary>
        /// <param name="view">Shell tab instance.</param>
        /// <param name="value">Value.</param>
        public static void SetText(BindableObject view, string value) =>
            view.SetValue(TextProperty, value);

        /// <summary>
        /// Public method to retrieve text color value for specific shell tab.
        /// </summary>
        /// <param name="target">Shell tab instance.</param>
        /// <returns>Text color for specific shell tab.</returns>
        public static Color GetTextColor(BindableObject target) =>
            (Color)target.GetValue(TextColorProperty);

        /// <summary>
        /// Public method to set text color value for specific shell tab.
        /// </summary>
        /// <param name="view">Shell tab instance.</param>
        /// <param name="value">Value.</param>
        public static void SetTextColor(BindableObject view, Color value) =>
            view.SetValue(TextColorProperty, value);

        /// <summary>
        /// Public method to retrieve background color value for specific shell tab.
        /// </summary>
        /// <param name="target">Shell tab instance.</param>
        /// <returns>Color for specific shell tab.</returns>
        public static Color GetBackgroundColor(BindableObject target) =>
            (Color)target.GetValue(BackgroundColorProperty);

        /// <summary>
        /// Public method to set background color value for specific shell tab.
        /// </summary>
        /// <param name="view">Shell tab instance.</param>
        /// <param name="value">Value.</param>
        public static void SetBackgroundColor(BindableObject view, Color value) =>
            view.SetValue(BackgroundColorProperty, value);

        #endregion
    }
}
