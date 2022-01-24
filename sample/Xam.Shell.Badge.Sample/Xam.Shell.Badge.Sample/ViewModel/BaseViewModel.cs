using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xam.Shell.Badge.Sample
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel() { }

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}