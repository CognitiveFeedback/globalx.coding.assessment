using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalX.Coding.Assessment.Sorting
{
    public static class QuickSort<T> where T : IComparable<T>
    {
        public static T[] Sort(T[] list)
        {
            Sort(list, 0, list.Length - 1);
            return list;
        }

        private static void Sort(T[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0)
            {
                return;
            }

            var index = Partition(A, left, right);

            if (index != -1)
            {
                Sort(A, left, index - 1);
                Sort(A, index + 1, right);
            }
        }

        private static int Partition(T[] A, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            var end = left;

            var pivot = A[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (A[i].CompareTo(pivot) < 0)
                {
                    Swap(A, i, end);
                    end++;
                }
            }

            Swap(A, end, right);

            return end;
        }

        private static void Swap(T[] A, int left, int right)
        {
            var tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
    }
}
