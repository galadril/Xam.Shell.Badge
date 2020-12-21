using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xam.Shell.Badge.Sample
{
    /// <summary>
    /// Defines the <see cref="BaseViewModel" />.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
        }

        #endregion

        #region Protected

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
