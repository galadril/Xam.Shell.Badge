using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Shell.Badge.Sample
{
    /// <summary>
    /// Defines the <see cref="MainPage" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Private

        /// <summary>
        /// The btnRemove_Clicked.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnRemove_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "RemoveBadge");
        }

        /// <summary>
        /// The btnColor_Clicked.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnColor_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ChangeColorBadge");
        }

        /// <summary>
        /// The btnText_Clicked.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnText_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ChangeTextBadge");
        }

        #endregion
    }
}
