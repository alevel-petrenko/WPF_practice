using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class testMyUnderstanding<T> where T: IComparable
    {
        public void Sort (T [] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var temp = array[i];
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (array[j].CompareTo(temp) > 0)
                    {
                        array[j + 1] = array[j];
                    }
                    else
                        break;
                }
                array[j+1] = temp;
            }
        }
    }
}
