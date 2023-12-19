using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions_Task5
{
    internal class Shuffle
    {
        public static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            string[] array2 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", };

            Random random = new();

            PrintArray(array1);
            ShuffleArray(array1, random);
            PrintArray(array1);

            PrintArray(array2);
            ShuffleArray(array2, random);
            PrintArray(array2);
        }

        private static void PrintArray<T>(T[] array)
        {
            foreach(T item in array)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine();
        }

        private static void ShuffleArray<T>(T[] array, Random random)
        {
            int[] indexes = new int[array.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = i;
            }

            int randomIndex = GetRandomItem(indexes, random);
            indexes = RemoveItemFromArray(indexes, randomIndex);

            int firstRandomIndex = randomIndex;
            T randomItem = array[randomIndex];

            while (indexes.Length > 0)
            {
                randomIndex = GetRandomItem(indexes, random);
                indexes = RemoveItemFromArray(indexes, randomIndex);

                (randomItem, array[randomIndex]) = (array[randomIndex], randomItem);
            }

            array[firstRandomIndex] = randomItem;
        }

        private static T GetRandomItem<T>(T[] array, Random random)
        {
            int randomMin = 0;
            int randomMax = array.Length;

            int randomIndex = random.Next(randomMin, randomMax);
            T randomItem = array[randomIndex];

            return randomItem;
        }

        private static T[] RemoveItemFromArray<T>(T[] array, T item)
        {
            int itemIndex = GetItemIndexInArray(array, item);

            T[] newArray = new T[array.Length - 1];

            int leftPartLength = itemIndex;
            int rightPartLength = array.Length - leftPartLength - 1;

            CopyArray(array, 0, newArray, 0, leftPartLength);
            CopyArray(array, itemIndex + 1, newArray, itemIndex, rightPartLength);

            return newArray;
        }

        private static int GetItemIndexInArray<T>(T[] array, T item)
        {
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    index = i;
                }
            }

            return index;
        }

        private static void CopyArray<T>(
            T[] source,
            int sourceIndex,
            T[] destination,
            int destinationIndex,
            int length)
        {
            int sourceRightBorder = sourceIndex + length;
            int destinationRightBorder = destinationIndex + length;

            if (sourceRightBorder > source.Length
                || destinationRightBorder > destination.Length)
            {
                throw new IndexOutOfRangeException(
                    $"Source - border: {sourceRightBorder}, length: {source.Length}" +
                    $"Destination - border: {destinationRightBorder}, length: {destination.Length}");
            }

            for (int i = 0; i < length; ++i)
            {
                destination[destinationIndex++] = source[sourceIndex++];
            }
        }
    }
}
