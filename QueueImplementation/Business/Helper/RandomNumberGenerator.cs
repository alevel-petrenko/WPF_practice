using System;

namespace Business.Helper
{
    /// <summary>
    /// Represents functionality for getting random number.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public static class RandomNumberGenerator
    {
        /// <summary>
        /// Holds the random class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private static readonly Random random = new Random();

        /// <summary>
        /// Gets the value from the range.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The value from the range.</returns>
        public static int GetValue() => random.Next(-1000, 1000);
    }
}