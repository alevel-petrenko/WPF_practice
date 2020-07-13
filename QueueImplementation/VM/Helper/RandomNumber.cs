using System;
using System.Threading;

namespace ViewModel.Helper
{
    /// <summary>
    /// Class represents functionality for getting random number.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public static class RandomNumber
    {
        /// <summary>
        /// Holds the random class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private static Random random = new Random();

        /// <summary>
        /// Gets the value from the range.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The value from the range.</returns>
        public static int GetValue()
        {
            //Thread.Sleep(1000);
            return random.Next(-1000, 1000);
        }
    }
}