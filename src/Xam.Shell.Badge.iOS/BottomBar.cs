using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xam.Shell.Badge.iOS.Renderers;

namespace Xam.Shell.Badge.iOS
{
    public static class BottomBar
    {
        public static void Init()
        {
            System.Diagnostics.Debug.Assert(typeof(CustomShellBottomAppearance) != null);
            System.Diagnostics.Debug.Assert(typeof(CustomShellRenderer) != null);
        }
    }
}