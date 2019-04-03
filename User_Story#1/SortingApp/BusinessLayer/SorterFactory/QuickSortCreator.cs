﻿using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Provides functionality that generates quick sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</type
    public class QuickSortCreator<T> : CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Generates instanse of QuickSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>instanse of QuickSorter.</returns>
        public override CollectionSorterBase<T> Create()
        {
            return new QuickSorter<T>();
        }
    }
}
