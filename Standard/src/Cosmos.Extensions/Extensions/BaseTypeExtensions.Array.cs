using System;
using System.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        public static void Copy(this Array sourceArray, Array destinationArray, int length)
        {
            Array.Copy(sourceArray, destinationArray, length);
        }

        public static void Copy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        public static void Copy(this Array sourceArray, Array destinationArray, long length)
        {
            Array.Copy(sourceArray, destinationArray, length);
        }

        public static void Copy(this Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
        {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        public static void ConstrainedCopy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        public static void Clear(this Array array, int index, int length)
        {
            Array.Clear(array, index, length);
        }

        public static void ClearAll(this Array array)
        {
            Array.Clear(array, 0, array.Length);
        }

        public static int IndexOf(this Array array, object value)
        {
            return Array.IndexOf(array, value);
        }

        public static int IndexOf(this Array array, object value, int startIndex)
        {
            return Array.IndexOf(array, value, startIndex);
        }

        public static int IndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.IndexOf(array, value, startIndex, count);
        }

        public static int LastIndexOf(this Array array, object value)
        {
            return Array.LastIndexOf(array, value);
        }

        public static int LastIndexOf(this Array array, object value, int startIndex)
        {
            return Array.LastIndexOf(array, value, startIndex);
        }

        public static int LastIndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.LastIndexOf(array, value, startIndex, count);
        }

        public static bool WithinIndex(this Array array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        public static bool WithinIndex(this Array array, int index, int dimension)
        {
            if (dimension <= 0) throw new ArgumentOutOfRangeException(nameof(dimension));
            return index >= array.GetLowerBound(dimension) && index <= array.GetUpperBound(dimension);
        }

        public static void Reverse(this Array array)
        {
            Array.Reverse(array);
        }

        public static void Reverse(this Array array, int index, int length)
        {
            Array.Reverse(array, index, length);
        }

        public static void Sort(this Array array)
        {
            Array.Sort(array);
        }

        public static void Sort(this Array array, Array items)
        {
            Array.Sort(array, items);
        }

        public static void Sort(this Array array, int index, int length)
        {
            Array.Sort(array, index, length);
        }

        public static void Sort(this Array array, Array items, int index, int length)
        {
            Array.Sort(array, items, index, length);
        }

        public static void Sort(this Array array, IComparer comparer)
        {
            Array.Sort(array, comparer);
        }

        public static void Sort(this Array array, Array items, IComparer comparer)
        {
            Array.Sort(array, items, comparer);
        }

        public static void Sort(this Array array, int index, int length, IComparer comparer)
        {
            Array.Sort(array, index, length, comparer);
        }

        public static void Sort(this Array array, Array items, int index, int length, IComparer comparer)
        {
            Array.Sort(array, items, index, length, comparer);
        }

        public static int BinarySearch(this Array array, object value)
        {
            return Array.BinarySearch(array, value);
        }

        public static int BinarySearch(this Array array, int index, int length, object value)
        {
            return Array.BinarySearch(array, index, length, value);
        }

        public static int BinarySearch(this Array array, object value, IComparer comparer)
        {
            return Array.BinarySearch(array, value, comparer);
        }

        public static int BinarySearch(this Array array, int index, int length, object value, IComparer comparer)
        {
            return Array.BinarySearch(array, index, length, value, comparer);
        }
    }
}