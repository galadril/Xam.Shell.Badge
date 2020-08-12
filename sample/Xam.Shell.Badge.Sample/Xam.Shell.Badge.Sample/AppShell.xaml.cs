using Xamarin.Forms.Xaml;

namespace Xam.Shell.Badge.Sample
{
    /// <summary>
    /// Defines the <see cref="AppShell" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
        }

        #endregion
    }
}
