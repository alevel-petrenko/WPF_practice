using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.SortingTypes
{
    public class SelectionSort<T>: CollectionSorter <T> where T: IComparable
    {
        public SelectionSort()
        {
            //Here will be sort type from enum
        }

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
