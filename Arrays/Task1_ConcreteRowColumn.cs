using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task1
{
    internal class ConcreteRowColumn
    {
        public static void Main(string[] args)
        {
            int rowsCount = 7;
            int columnsCount = 5;

            int[,] array = new int[rowsCount, columnsCount];
            Random random = new Random();
            int randomMin = 1, randomMax = 10;

            int targetRow = 1;
            int targetColumn = 0;

            int resultMultiplication = 1;
            int resultSumm = 0;
            
            for (int y = 0; y < rowsCount; y++)
            { 
                for (int x = 0; x < columnsCount; x++)
                {
                    array[y, x] = random.Next(randomMin, randomMax);

                    if (y == targetRow)
                    {
                        resultSumm += array[y, x];
                    }

                    if (x == targetColumn)
                    {
                        resultMultiplication *= array[y, x];
                    }

                    Console.Write($"{array[y, x]} ");
                }

                Console.WriteLine("");
            }

            Console.WriteLine($"Mul: {resultMultiplication}, Sum: {resultSumm}");
        }
    }
}
