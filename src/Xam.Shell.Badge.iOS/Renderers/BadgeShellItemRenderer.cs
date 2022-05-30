﻿using AsyncAwaitBestPractices;
using CoreFoundation;
using System;
using System.Collections.Generic;
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
        static bool? s_isiOS15OrNewer;
        internal static bool IsiOS15OrNewer
        {
            get
            {
                if (!s_isiOS15OrNewer.HasValue)
                    s_isiOS15OrNewer = UIDevice.CurrentDevice.CheckSystemVersion(15, 0);
                return s_isiOS15OrNewer.Value;
            }
        }
    
        private readonly string[] _applyPropertyNames =
            new string[]
            {
                Badge.TextProperty.PropertyName,
                Badge.TextColorProperty.PropertyName,
                Badge.BackgroundColorProperty.PropertyName
            };

        private readonly Dictionary<Guid, int> _tabRealIndexByItemId =
            new Dictionary<Guid, int>();

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
                .InvokeOnMainThreadAsync(() =>
                {
                    var item = (ShellSection)sender;
                    if (item.IsVisible)
                    {
                        var index = _tabRealIndexByItemId.GetValueOrDefault(item.Id, -1);
                        UpdateBadge(item, index);
                    }
                })
                .SafeFireAndForget();
        }

        private void InitBadges()
        {
            _tabRealIndexByItemId.Clear();
            for (int index = 0, filteredIndex = 0; index < ShellItem.Items.Count; index++)
            {
                var item = ShellItem.Items.ElementAtOrDefault(index);
                if (!item.IsVisible)
                    continue;
                _tabRealIndexByItemId[item.Id] = filteredIndex;
                UpdateBadge(item, filteredIndex);
                filteredIndex++;
            }
        }

        private void UpdateBadge(ShellSection item, int index)
        {
            if (index < 0)
                return;

            var text = Badge.GetText(item);
            var textColor = Badge.GetTextColor(item);
            var bg = Badge.GetBackgroundColor(item);
            ApplyBadge(index, text, bg, textColor);
        }

        private void ApplyBadge(int index, string text, Color bg, Color textColor)
        {
            if (TabBar.Items.Any())
            {
                if (TabBar.Items.ElementAtOrDefault(index) is UITabBarItem currentTabBarItem)
                {
                    int.TryParse(text, out var badgeValue);

                    if (string.IsNullOrEmpty(text))
                    {
                        currentTabBarItem.BadgeValue = default;
                        currentTabBarItem.BadgeColor = UIColor.Clear;
                        return;
                    }

                    if (badgeValue == 0)
                    {
                        currentTabBarItem.BadgeValue = IsiOS15OrNewer ? "0" : "●";
                        currentTabBarItem.BadgeColor = UIColor.Clear;
                        currentTabBarItem.SetBadgeTextAttributes(
                            new UIStringAttributes
                            {
                                ForegroundColor = bg.ToUIColor()
                            }, UIControlState.Normal);
                    }
                    else
                    {
                        currentTabBarItem.BadgeValue = text;
                        currentTabBarItem.BadgeColor = bg.ToUIColor();
                        currentTabBarItem.SetBadgeTextAttributes(
                            new UIStringAttributes
                            {
                                ForegroundColor = textColor.ToUIColor()
                            }, UIControlState.Normal);
                    }
                    
                    if (IsiOS15OrNewer)
                    {
                        var appearance = new UITabBarAppearance();

                        appearance.StackedLayoutAppearance.Normal.BadgeTextAttributes = new UIStringAttributes { ForegroundColor = textColor.ToUIColor(), ParagraphStyle = NSParagraphStyle.Default };
                        appearance.StackedLayoutAppearance.Normal.BadgeBackgroundColor = bg.ToUIColor();

                        appearance.InlineLayoutAppearance.Normal.BadgeTextAttributes = new UIStringAttributes { ForegroundColor = textColor.ToUIColor(), ParagraphStyle = NSParagraphStyle.Default };
                        appearance.InlineLayoutAppearance.Normal.BadgeBackgroundColor = bg.ToUIColor();

                        appearance.CompactInlineLayoutAppearance.Normal.BadgeTextAttributes = new UIStringAttributes { ForegroundColor = textColor.ToUIColor(), ParagraphStyle = NSParagraphStyle.Default };
                        appearance.CompactInlineLayoutAppearance.Normal.BadgeBackgroundColor = bg.ToUIColor();

                        currentTabBarItem.ScrollEdgeAppearance = appearance;
                    }
                }
            }
        }
    }
}
