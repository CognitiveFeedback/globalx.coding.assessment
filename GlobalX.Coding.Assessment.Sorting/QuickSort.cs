﻿using System;

namespace GlobalX.Coding.Assessment.Sorting
{
    /// <summary>
    /// Static class implementing the classic Quick Sort algorithm
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QuickSort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sort an array of orderable items using the classic Quick Sort algorithm
        /// </summary>
        /// <param name="list">The array to be sorted</param>
        public static void Sort(T[] list)
        {
            Sort(list, 0, list.Length - 1);
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

            var pivot = A[right];
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
