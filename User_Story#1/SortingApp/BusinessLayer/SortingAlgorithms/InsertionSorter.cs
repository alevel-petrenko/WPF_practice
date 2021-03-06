﻿using System;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Provides functionality that sorts elements in an ascending order by Insertion type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorterBase{T}" />
    public class InsertionSorter<T> : CollectionSorterBase<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        public override void Sort(T[] inputCollection)
        {
            if (inputCollection is null)
                throw new ArgumentNullException(nameof(inputCollection));

            for (int i = 1; i < inputCollection.Length; i++)
            {
                var temp = inputCollection[i];
                int j = i - 1;
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
