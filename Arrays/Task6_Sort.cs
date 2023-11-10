using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task6
{
    internal class Sort
    {
        public static void Main(string[] args)
        {
            int arrayLength = 29;
            var array = new int[arrayLength];
            var bufferArray = new int[arrayLength];

            Random random = new Random();
            int maxRandomValue = 1000;
            int minRandomValue = 100;

            Console.WriteLine("Initial:");

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random.Next(minRandomValue, maxRandomValue);

                Console.Write($"{array[i]}, ");
            }

            int splitsCount = 2;
            int firstBatchSize = 1;

            //iterative merge sorting algorythm

            for (int batchSize = firstBatchSize; batchSize < arrayLength; batchSize *= splitsCount)
            {
                for (int batchStartIndex = 0; 
                    batchStartIndex < arrayLength; 
                    batchStartIndex += batchSize * splitsCount)
                {
                    int leftBatchIterator = batchStartIndex;
                    int rightBatchIterator = batchStartIndex + batchSize;
                    int leftBatchBorder = leftBatchIterator + batchSize;
                    int rightBatchBorder = rightBatchIterator + batchSize;
                    int bufferIterator = 0;

                    rightBatchBorder = rightBatchBorder < arrayLength ? rightBatchBorder : arrayLength;
                    leftBatchBorder = leftBatchBorder < arrayLength ? leftBatchBorder : arrayLength;

                    while (leftBatchIterator < leftBatchBorder && rightBatchIterator < rightBatchBorder)
                    {
                        if (array[leftBatchIterator] <= array[rightBatchIterator])
                        {
                            bufferArray[bufferIterator] = array[leftBatchIterator];
                            leftBatchIterator++;
                        } 
                        else
                        {
                            bufferArray[bufferIterator] = array[rightBatchIterator];
                            rightBatchIterator++;
                        }

                        bufferIterator++;
                    }

                    while (leftBatchIterator < leftBatchBorder)
                    {
                        bufferArray[bufferIterator] = array[leftBatchIterator];
                        leftBatchIterator++;
                        bufferIterator++;
                    }

                    while (rightBatchIterator < rightBatchBorder)
                    {
                        bufferArray[bufferIterator] = array[rightBatchIterator];
                        rightBatchIterator++;
                        bufferIterator++;
                    }

                    int numberOfBytes = bufferIterator * sizeof(int);
                    int dstOffsetInBytes = batchStartIndex * sizeof(int);

                    Buffer.BlockCopy(bufferArray, 0, array, dstOffsetInBytes, numberOfBytes);
                }
            }

            Console.WriteLine("\nSorted:");

            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write($"{array[i]}, ");
            }
        }
    }
}
