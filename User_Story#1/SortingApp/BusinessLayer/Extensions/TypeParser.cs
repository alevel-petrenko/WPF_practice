using System;

namespace BusinessLayer.Extentions
{
    public static class TypeParser
    {
        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
