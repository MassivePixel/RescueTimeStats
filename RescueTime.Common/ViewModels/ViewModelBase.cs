using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MassivePixel.RescueTime.Common.ViewModels
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        private interface IWrapper { }

        private class Wrapper<T> : IWrapper
        {
            public T Value { get; set; }
        }

        private readonly Dictionary<string, IWrapper> _fields = new Dictionary<string, IWrapper>();

        protected T Get<T>([CallerMemberName] string propertyName = "")
        {
            IWrapper wrapper;
            if (!_fields.TryGetValue(propertyName, out wrapper))
                return default(T);
            return ((Wrapper<T>)wrapper).Value;
        }

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = "")
        {
            bool equal;
            IWrapper wrapper;
            if (!_fields.TryGetValue(propertyName, out wrapper))
            {
                _fields.Add(propertyName, new Wrapper<T> { Value = value });
                equal = false;
            }
            else
            {
                var twrapper = (Wrapper<T>)wrapper;
                equal = EqualityComparer<T>.Default.Equals(twrapper.Value, value);
                twrapper.Value = value;
            }

            if (!equal)
                RaisePropertyChanged(propertyName);

            return equal;
        }

        protected new bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            return Set(propertyName, ref field, value);
        }
    }
}
