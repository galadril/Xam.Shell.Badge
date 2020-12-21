using System;
using Xamarin.Forms;

namespace Xam.Shell.Badge.Sample
{
    /// <summary>
    /// Defines the <see cref="ShellViewModel" />.
    /// </summary>
    public class ShellViewModel : BaseViewModel
    {
        #region Variables

        /// <summary>
        /// Defines the colors.
        /// </summary>
        private Color[] colors = new[] { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Aqua };

        /// <summary>
        /// Defines the randonGen.
        /// </summary>
        private Random randonGen = new Random();

        /// <summary>
        /// Defines the badge1Text.
        /// </summary>
        private string badge1Text;

        /// <summary>
        /// Defines the badge1Color.
        /// </summary>
        private Color badge1Color;

        #endregion

        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        public ShellViewModel()
        {
            Badge1Text = "5";
            MessagingCenter.Subscribe<MainPage>(this, "RemoveBadge", app => RemoveBadge());
            MessagingCenter.Subscribe<MainPage>(this, "ChangeColorBadge", app => ChangeColor());
            MessagingCenter.Subscribe<MainPage>(this, "ChangeTextBadge", app => ChangeText());
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Badge1Text.
        /// </summary>
        public string Badge1Text
        {
            get { return badge1Text; }
            set
            {
                badge1Text = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Badge1Color.
        /// </summary>
        public Color Badge1Color
        {
            get { return badge1Color; }
            set
            {
                badge1Color = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// The ChangeColor.
        /// </summary>
        private void ChangeColor()
        {
            if (string.IsNullOrEmpty(Badge1Text)) 
                ChangeText();

            Badge1Color = colors[randonGen.Next(0, colors.Length)];
        }

        /// <summary>
        /// The ChangeText.
        /// </summary>
        private void ChangeText()
        {
            Badge1Text = randonGen.Next(0, 100).ToString();
        }

        /// <summary>
        /// The RemoveBadge.
        /// </summary>
        private void RemoveBadge()
        {
            Badge1Text = "";
        }

        #endregion
    }
}
