using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareSortAlgorythms
{
    public static class QuickSort
    {
        public static void Sort(int[] elements)
        {
            SortRecursive(elements, 0, elements.Length - 1);
        }

        private static void SortRecursive(int[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                SortRecursive(elements, left, j);
            }

            if (i < right)
            {
                SortRecursive(elements, i, right);
            }
        }

    }
}