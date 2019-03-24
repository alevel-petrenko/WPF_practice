using SortAlgorithms.SortingTypes;
using System;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new int[] { 6, 1, 8, 0,5, 7, 150, 98, 56, 11, -5 };
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            var IS = new QuickSort<int>();
            IS.Sort(list);

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
