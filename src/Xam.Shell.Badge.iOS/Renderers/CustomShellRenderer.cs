using Xam.Shell.Badge.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace Xam.Shell.Badge.iOS.Renderers
{
   /// <summary>
   /// The CustomShellRenderer is necessary in order to replace the ShellItemRenderer with your own.
   /// </summary>
   class CustomShellRenderer : ShellRenderer
   {
      public CustomShellRenderer() : base()
      { }

      protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
      {
         return new CustomShellBottomAppearance();
      }
   }
}