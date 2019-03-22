using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    abstract public class CollectionSorter<T>
    {
        abstract public void Sort(T[] inputCollection);
    }
}
