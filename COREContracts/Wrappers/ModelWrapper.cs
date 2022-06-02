using COREContracts.Base;
using System;
using System.Runtime.CompilerServices;

namespace COREContracts.Wrappers
{
    public class ModelWrapper<T> : Observable
    {
        public ModelWrapper(T model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public T Model { get; }

        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            if (!Equals(currentValue, value))
            {
                propertyInfo.SetValue(Model, value);
                OnPropertyChanged(propertyName);
            }
        }
        
        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue)propertyInfo.GetValue(Model);
        }
    }
}
