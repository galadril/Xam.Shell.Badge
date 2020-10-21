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
        /// The Button_Clicked.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            new BottomBarHelper().SetBadge(1, 2);
            new BottomBarHelper().SetTi(1, 2);
        }

        /// <summary>
        /// The Button_Clicked_1.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            new BottomBarHelper().RemoveBadge(1);
        }

        #endregion
    }
}
