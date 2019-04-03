using System;

namespace BusinessLayer.Extensions
{
    /// <summary>
    /// Provides functionality that parses input value type of object in specific type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public static class TypeParser
    {
        /// <summary>
        /// Changes the type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <typeparam name="T">Certain input type.</typeparam>
        /// <param name="obj">The input object.</param>
        /// <returns>Specific type.</returns>
        public static T ChangeType<T>(this object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
