using System.Collections.Generic;
using System.ComponentModel;

namespace LucAdm
{
    public class Validated<T>
    {
        public Validated(T val)
        {
            Value = val;
        }

        public T Value { get; set; }
        public bool IsValid { get; set; }

        public static implicit operator Validated<T>(T val)
        {
            return new Validated<T>(val);
        }

        public static implicit operator Validated<T>(string rawValue)
        {
            var converter = TypeDescriptor.GetConverter(typeof (T));

            if (converter.IsValid(rawValue))
            {
                return new Validated<T>((T) converter.ConvertFromString(rawValue)) {IsValid = true};
            }
            return new Validated<T>(default(T)) {IsValid = false};
        }

        public static implicit operator T(Validated<T> val)
        {
            return val.Value;
        }

        public override string ToString()
        {
            if (Value == null)
            {
                return string.Empty;
            }
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null && Value != null)
            {
                return false;
            }
            if (obj != null && obj.GetType() != typeof (T))
            {
                return false;
            }
            return EqualityComparer<T>.Default.Equals(Value, (T) obj);
        }

        public override int GetHashCode()
        {
            if (Value == null)
            {
                return 0;
            }
            return Value.GetHashCode();
        }
    }
}