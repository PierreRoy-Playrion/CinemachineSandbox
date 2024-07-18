using UniRx;
using UnityEngine;

namespace CinemachineSandbox.Tools
{
    public abstract class Variable<T> : ScriptableObject
    {
        private ReactiveProperty<T> _value = new ();
        
        public T Value => _value.Value;
        public ReactiveProperty<T> Property => _value;

        public void SetValue(T value, bool forceNotify = true)
        {
            if (forceNotify)
            {
                _value.SetValueAndForceNotify(value);
            }
            else
            {
                _value.Value = value;
            }
        }
        
        public void Clear()
        {
            _value.Value = default;
        }
    }
}