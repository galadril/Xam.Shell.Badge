using Xamarin.Forms;

namespace Xam.Shell.Badge.Sample
{
    /// <summary>
    /// Defines the <see cref="App" />.
    /// </summary>
    public partial class App : Application
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        #endregion

        #region Protected

        /// <summary>
        /// The OnStart.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// The OnSleep.
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// The OnResume.
        /// </summary>
        protected override void OnResume()
        {
        }

        #endregion
    }
}
