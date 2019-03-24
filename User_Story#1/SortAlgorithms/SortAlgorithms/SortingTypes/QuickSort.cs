using System;

namespace SortAlgorithms.SortingTypes
{
    class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            for (int i = 0, j = 0; i < inputCollection.Length;)
            {
                var pivot = inputCollection[inputCollection.Length - 1];

                if (inputCollection[j].CompareTo(pivot)>0)
                {
                    i++;
                    continue;
                }
                else
                {
                    var temp = inputCollection[i];
                    inputCollection[i] = inputCollection[j];
                    inputCollection[j] = temp;
                }
            }
        }
    }
}
