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
        /// <param name="item">The input object.</param>
        /// <returns>Specific type.</returns>
        public static T ChangeType<T>(this object item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            return (T)Convert.ChangeType(item, typeof(T));
        }
    }
}
