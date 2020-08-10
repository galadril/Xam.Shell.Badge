using Android.Content;
using Xam.Shell.Badge.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace Xam.Shell.Badge.Droid.Renderers
{
   /// <summary>
   /// The CustomShellRenderer is necessary in order to replace the ShellItemRenderer with your own.
   /// </summary>
   class CustomShellRenderer : ShellRenderer
   {
      public CustomShellRenderer(Context context) : base(context)
      { }

      protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
      {
         return new CustomShellBottomAppearance(this);
      }
   }
}
