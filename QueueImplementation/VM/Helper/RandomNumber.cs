using System;
using System.Threading;

namespace ViewModel.Helper
{
    public static class RandomNumber
    {
        private static Random random = new Random();

        public static int GetValue()
        {
            Thread.Sleep(1000);
            return random.Next(-1000, 1000);
        }
    }
}