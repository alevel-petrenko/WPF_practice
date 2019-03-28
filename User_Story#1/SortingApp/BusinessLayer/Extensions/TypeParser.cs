﻿using System;

namespace BusinessLayer.Extensions
{
    /// <summary>
    /// Parses input value type of object in specific type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public static class TypeParser
    {
        /// <summary>
        /// Changes the type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The input object.</param>
        /// <returns>Specific type.</returns>
        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
