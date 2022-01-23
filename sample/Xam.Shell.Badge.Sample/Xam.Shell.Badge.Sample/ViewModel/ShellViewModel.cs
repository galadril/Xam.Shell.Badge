using System;
using Xamarin.Forms;

namespace Xam.Shell.Badge.Sample
{
    public class ShellViewModel : BaseViewModel
    {
        /// <summary>
        /// Defines the colors.
        /// </summary>
        private readonly Color[] _colors =
            new[] { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Aqua };

        /// <summary>
        /// Defines the randonGen.
        /// </summary>
        private readonly Random _randonGen = new Random();

        /// <summary>
        /// Defines the badge1Text.
        /// </summary>
        private string _badge1Text = "5";

        /// <summary>
        /// Defines the badge1Color.
        /// </summary>
        private Color _badge1Color = Color.Green;

        public ShellViewModel()
        {
            MessagingCenter.Subscribe<MainPage>(this, "RemoveBadge", RemoveBadge);
            MessagingCenter.Subscribe<MainPage>(this, "ChangeColorBadge", ChangeColor);
            MessagingCenter.Subscribe<MainPage>(this, "ChangeTextBadge", ChangeText);
            MessagingCenter.Subscribe<MainPage>(this, "ChangeTextToZero", ChangeTextToZero);
        }

        /// <summary>
        /// Gets or sets the Badge1Text.
        /// </summary>
        public string Badge1Text
        {
            get => _badge1Text;
            set
            {
                _badge1Text = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Badge1Color.
        /// </summary>
        public Color Badge1Color
        {
            get => _badge1Color;
            set
            {
                _badge1Color = value;
                OnPropertyChanged();
            }
        }

        private void ChangeColor(MainPage _)
        {
            if (string.IsNullOrEmpty(Badge1Text)) 
                ChangeText(_);

            Badge1Color = _colors[_randonGen.Next(0, _colors.Length)];
        }

        private void ChangeText(MainPage _)
        {
            Badge1Text = _randonGen.Next(0, 100).ToString();
        }

        private void ChangeTextToZero(MainPage _)
        {
            Badge1Text = "0";
        }

        private void RemoveBadge(MainPage _)
        {
            Badge1Text = string.Empty;
        }
    }
}