using System.Collections.Generic;
using AView = Android.Views.View;
using AViewGroup = Android.Views.ViewGroup;

namespace Xam.Shell.Badge.Droid.Extensions
{
    /// <summary>
    /// Defines the <see cref="ViewGroupExtensions" />.
    /// </summary>
    internal static class ViewGroupExtensions
    {
        #region Internal

        /// <summary>
        /// The GetChildrenOfType.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="self">The self<see cref="AViewGroup"/>.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        internal static IEnumerable<T> GetChildrenOfType<T>(this AViewGroup self) where T : AView
        {
            for (var i = 0; i < self.ChildCount; i++)
            {
                AView child = self.GetChildAt(i);
                var typedChild = child as T;
                if (typedChild != null)
                    yield return typedChild;

                if (child is AViewGroup)
                {
                    IEnumerable<T> myChildren = (child as AViewGroup).GetChildrenOfType<T>();
                    foreach (T nextChild in myChildren)
                        yield return nextChild;
                }
            }
        }

        #endregion
    }
}
