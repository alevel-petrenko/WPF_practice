﻿using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Provides functionality that creates insertion sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    public class InsertionSortCreator<T> : CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Creates instanse of InsertionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instanse of InsertionSorter.</returns>
        public override CollectionSorterBase<T> Create()
        {
            return new InsertionSorter<T>();
        }
    }
}
