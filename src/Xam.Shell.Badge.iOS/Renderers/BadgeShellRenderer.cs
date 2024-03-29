﻿using Xam.Shell.Badge.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(BadgeShellRenderer))]
namespace Xam.Shell.Badge.iOS.Renderers
{
    /// <summary>
    /// The BadgeShellRenderer is necessary in order to replace the ShellItemRenderer with this custom one.
    /// </summary>
    public class BadgeShellRenderer : ShellRenderer
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item) =>
            new BadgeShellItemRenderer(this) { ShellItem = item };
    }
}