using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xam.Shell.Badge.Droid.Renderers
{
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext)
        { }

        protected override void OnTabReselected(ShellSection shellSection)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await shellSection?.Navigation.PopToRootAsync();
            });
        }
    }
}