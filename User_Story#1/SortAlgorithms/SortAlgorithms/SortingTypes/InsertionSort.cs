using System;
using System.Linq;

namespace SortAlgorithms.SortingTypes
{
    public class InsertionSort<T> : CollectionSorter<T> where T : IComparable
    {
        public InsertionSort()
        {
            //Here will be sort type from enum
        }

        public override void Sort (T[] inputCollection)
        {
            for (int i = 1; i < inputCollection.Count(); i++)
            {
                var temp = inputCollection[i];
                int j = i-1;
                while ((j >= 0) && (inputCollection[j].CompareTo(temp) > 0))
                {
                    inputCollection[j + 1] = inputCollection[j];
                    j--;
                }
                inputCollection[j + 1] = temp;
            }
        }
    }
}
