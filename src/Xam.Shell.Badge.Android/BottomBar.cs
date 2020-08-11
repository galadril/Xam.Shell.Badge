using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xam.Shell.Badge.Droid.Renderers;

namespace Xam.Shell.Badge.Droid
{
    public static class BottomBar
    {
        public static void Init()
        {
            System.Diagnostics.Debug.Assert(typeof(CustomShellBottomAppearance) != null);
            System.Diagnostics.Debug.Assert(typeof(CustomShellItemRenderer) != null);
            System.Diagnostics.Debug.Assert(typeof(CustomShellRenderer) != null);
        }
    }
}