using SortAlgorithms.SortingTypes;
using System;

namespace SortAlgorithms
{
    class SortTest<T> : CollectionSorter<T> where T : IComparable
    {
        //insertion
        //public override void Sort(T[] inputCollection)
        //{
        //    for (int i = 1; i < inputCollection.Count(); i++)
        //    {
        //        var temp = inputCollection[i];
        //        int j = i - 1;
        //        for (; j>=0; j--)
        //        {
        //            if (inputCollection[j].CompareTo(temp) > 0)
        //            {
        //                inputCollection[j + 1] = inputCollection[j];
        //            }
        //            else
        //                break;
        //        }
        //        inputCollection[j+1] = temp;
        //    }
        //}

        //selection
        public override void Sort(T[] inputCollection)
        {
            for (int i = 0; i < inputCollection.Length; i++)
            {
                var min = inputCollection[i];
                for (int j = i+1; j < inputCollection.Length; j++)
                {
                    if (inputCollection[j].CompareTo(min) < 0)
                        min = inputCollection[j];
                }
                inputCollection[Array.IndexOf(inputCollection, min)] = inputCollection[i];
                inputCollection[i] = min;
            }
        }
    }
}
