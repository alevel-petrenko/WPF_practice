﻿using System;

namespace SortAlgorithms.SortingTypes
{
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            SortSubArray(inputCollection, 0, inputCollection.Length);
        }

        private void SortSubArray(T[] inputCollection, int start, int end)
        {
            if (inputCollection != null && start >= 0 || end >= 0)
            {
                if (start >= end)
                {
                    return;
                }
                int pivot = end - 1;
                int wall = start;
                for (int currentIndex = start; currentIndex < end; currentIndex++)
                {
                    if (inputCollection[currentIndex].CompareTo(inputCollection[pivot]) <= 0)
                    {
                        SwapElements(inputCollection, currentIndex, wall);
                        wall++;
                    }
                }
                SortSubArray(inputCollection, start, wall - 1);
                SortSubArray(inputCollection, wall + 1, end);
            }
        }

        private void SwapElements(T[] collection, int rightIndex, int leftIndex)
        {
            if (collection != null && rightIndex >= 0 || leftIndex >= 0)
            {
                var temp = collection[rightIndex];
                collection[rightIndex] = collection[leftIndex];
                collection[leftIndex] = temp;
            }
        }
    }
}