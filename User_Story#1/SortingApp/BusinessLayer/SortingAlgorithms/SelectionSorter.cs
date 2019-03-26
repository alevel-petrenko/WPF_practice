using System;
using System.Linq;

namespace BusinessLayer.SortingAlgorithms
{
    public class SelectionSort<T> : CollectionSorter<T> where T : IComparable
    {

        public override void Sort(T[] inputCollection)
        {
            for (int i = 0; i < inputCollection.Count(); i++)
            {
                var min = inputCollection[i];
                int j = i + 1;
                for (; j < inputCollection.Count(); j++)
                {
                    if (min.CompareTo(inputCollection[j]) > 0)
                    {
                        min = inputCollection[j];
                    }
                }
                inputCollection[Array.IndexOf(inputCollection, min)] = inputCollection[i];
                inputCollection[i] = min;
            }
        }
    }
}
