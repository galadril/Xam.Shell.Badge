using AsyncAwaitBestPractices;
using CoreFoundation;
using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Xam.Shell.Badge.iOS.Renderers
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class BadgeShellItemRenderer : ShellItemRenderer
    {
        private readonly string[] _applyPropertyNames =
            new string[]
            {
                Badge.TextProperty.PropertyName,
                Badge.TextColorProperty.PropertyName,
                Badge.BackgroundColorProperty.PropertyName
            };

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public BadgeShellItemRenderer(IShellContext context) : base(context) { }

        /// <summary>
        /// Occures when view is about to appear.
        /// </summary>
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                Device
                    .InvokeOnMainThreadAsync(InitBadges)
                    .SafeFireAndForget();
            });
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnShellSectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnShellSectionPropertyChanged(sender, e);

            if (_applyPropertyNames.All(x => x != e.PropertyName))
                return;

            Device
                .InvokeOnMainThreadAsync(() => UpdateBadge((ShellSection)sender))
                .SafeFireAndForget();
        }

        private void InitBadges()
        {
            for (int index = 0; index < ShellItem.Items.Count; index++)
            {
                UpdateBadge(ShellItem.Items.ElementAtOrDefault(index));
            }
        }

        private void UpdateBadge(ShellSection item)
        {
            var index = ShellItem.Items.IndexOf(item);
            var text = Badge.GetText(item);
            var textColor = Badge.GetTextColor(item);
            var bg = Badge.GetBackgroundColor(item);
            ApplyBadge(index, text, bg, textColor);
        }

        private void ApplyBadge(int index, string text, Color bg, Color textColor)
        {
            if (TabBar.Items.Any())
            {
                if (default == TabBar.Items.ElementAtOrDefault(index))
                    return;

                int.TryParse(text, out var badgeValue);

                if (!string.IsNullOrEmpty(text))
                {
                    if (badgeValue == 0)
                    {
                        TabBar.Items[index].BadgeValue = "●";
                        TabBar.Items[index].BadgeColor = UIColor.Clear;
                    }
                    else
                    {
                        TabBar.Items[index].BadgeValue = text;
                        TabBar.Items[index].BadgeColor = bg.ToUIColor();
                    }

                    TabBar.Items[index].SetBadgeTextAttributes(
                        new UIStringAttributes
                        {
                            ForegroundColor = textColor.ToUIColor()
                        }, UIControlState.Normal);
                }
                else
                {
                    TabBar.Items[index].BadgeValue = default;
                    TabBar.Items[index].BadgeColor = UIColor.Clear;
                }
            }
        }
    }
}