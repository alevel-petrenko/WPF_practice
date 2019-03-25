using SortAlgorithms.SortingTypes;
using System;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new int[] { 8, 56, 42, 4, 75, 1024, 2, 98, 3 };
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
            Console.ReadLine();
        }
    }
}
