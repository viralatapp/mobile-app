using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace ViralatApp.Helpers
{
    public static class ExtensionEnumerable
    {
        public static void AddRange<T>(this ObservableCollection<T> myEnumerable,  IEnumerable<T> enumerable)
        {
            myEnumerable.ForEach(myEnumerable.Add);
        }
    }
}