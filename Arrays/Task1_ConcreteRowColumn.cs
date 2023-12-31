﻿using System;
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

            var array = new int[rowsCount, columnsCount];
            Random random = new Random();
            int randomMin = 1;
            int randomMax = 10;

            int targetRow = 1;
            int targetColumn = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(randomMin, randomMax);

                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine("");
            }

            int resultSumm = 0;

            for (int j = 0; j < array.GetLength(1); j++)
            {
                resultSumm += array[targetRow, j];
            }

            int resultMultiplication = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                resultMultiplication *= array[i, targetColumn];
            }

            Console.WriteLine($"Mul: {resultMultiplication}, Sum: {resultSumm}");
        }
    }
}
