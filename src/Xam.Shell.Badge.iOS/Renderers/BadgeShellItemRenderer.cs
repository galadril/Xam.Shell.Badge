using System;
using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Xam.Shell.Badge.iOS.Renderers
{
    /// <summary>
    /// Defines the <see cref="BadgeShellItemRenderer" />.
    /// </summary>
    public class BadgeShellItemRenderer : ShellItemRenderer
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeShellItemRenderer"/> class.
        /// </summary>
        /// <param name="context">The shellContext<see cref="IShellContext"/>.</param>
        public BadgeShellItemRenderer(IShellContext context) : base(context) { }

        #endregion

        #region Public

        /// <summary>
        /// Occures when view is about to appear
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            for (int i = 0; i < ShellItem.Items.Count; i++)
            {
                var item = ShellItem.Items.ElementAtOrDefault(i);
                var text = Badge.GetText(item);
                var textColor = Badge.GetTextColor(item);
                var bg = Badge.GetBackgroundColor(item);
                ApplyBadge(i, text, bg, textColor);
            }
        }

        #endregion

        #region Protected

        /// <summary>
        /// Occures when property changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShellSectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnShellSectionPropertyChanged(sender, e);

            if (e.PropertyName == Badge.TextProperty.PropertyName ||
                e.PropertyName == Badge.TextColorProperty.PropertyName ||
                e.PropertyName == Badge.BackgroundColorProperty.PropertyName)
            {
                var item = (ShellSection)sender;
                var index = ShellItem.Items.IndexOf(item);
                var text = Badge.GetText(item);
                var textColor = Badge.GetTextColor(item);
                var bg = Badge.GetBackgroundColor(item);
                if (!string.IsNullOrEmpty(text))
                    ApplyBadge(index, text, bg, textColor);
            }
        }

        #endregion

        #region Private

        private void ApplyBadge(int index, string text, Color bg, Color textColor)
        {
            if (TabBar?.Items != null && TabBar.Items.Any())
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var badgeValue = Convert.ToInt32(text);
                    if (badgeValue > 0)
                    {
                        TabBar.Items[index].BadgeValue = text;
                        TabBar.Items[index].BadgeColor = bg.ToUIColor();
                        TabBar.Items[index]
                            .SetBadgeTextAttributes(new UIStringAttributes()
                            {
                                ForegroundColor = textColor.ToUIColor()
                            }, UIControlState.Normal);
                    }
                    else
                    {
                        TabBar.Items[index].BadgeValue = "●";
                        TabBar.Items[index].BadgeColor = UIColor.Clear;
                        TabBar.Items[index]
                            .SetBadgeTextAttributes(new UIStringAttributes()
                            {
                                ForegroundColor = textColor.ToUIColor()
                            }, UIControlState.Normal);
                    }
                }
                else
                {
                    TabBar.Items[index].BadgeValue = null;
                    TabBar.Items[index].BadgeColor = UIColor.Clear;
                }
            }
        }

        #endregion
    }
}