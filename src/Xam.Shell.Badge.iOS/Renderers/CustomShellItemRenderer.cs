using System;
using System.Collections.Specialized;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Xam.Shell.Badge.iOS.Renderers
{
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        public CustomShellItemRenderer(IShellContext context) : base(context) { }

        protected override void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsCollectionChanged(sender, e);

            for (int i = 0; i < ShellItem.Items.Count; i++)
            {
                var item = ShellItem.Items.ElementAtOrDefault(i);
                var text = Badging.GetBadgeText(item);
                var textColor = Badging.GetBadgeTextColor(item);
                var bg = Badging.GetBadgeBackgroundColor(item);
                ApplyBadge(i, text, bg, textColor);
            }
        }

        private void ApplyBadge(int index, string text, Color bg, Color textColor)
        {
            if(TabBarController?.TabBar?.Items != null && TabBarController.TabBar.Items.Any())
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var badgeValue = Convert.ToInt32(text);
                    if (badgeValue > 0)
                    {
                        TabBarController.TabBar.Items[index].BadgeValue = text;
                        TabBarController.TabBar.Items[index].BadgeColor = bg.ToUIColor();
                        TabBarController.TabBar.Items[index]
                            .SetBadgeTextAttributes(new UIStringAttributes()
                            {
                                ForegroundColor = textColor.ToUIColor()
                            }, UIControlState.Normal);
                    }
                    else
                    {
                        TabBarController.TabBar.Items[index].BadgeValue = "●";
                        TabBarController.TabBar.Items[index].BadgeColor = UIColor.Clear;
                        TabBarController.TabBar.Items[index]
                            .SetBadgeTextAttributes(new UIStringAttributes()
                            {
                                ForegroundColor = textColor.ToUIColor()
                            }, UIControlState.Normal);
                    }
                }
                else
                {
                    TabBarController.TabBar.Items[index].BadgeValue = null;
                    TabBarController.TabBar.Items[index].BadgeColor = UIColor.Clear;
                }
            }
        }
    }
}