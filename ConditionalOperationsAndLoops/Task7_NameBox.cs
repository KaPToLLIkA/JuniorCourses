using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task7
{
    internal class NameBox
    {
        public static void Main(string[] args)
        {
            Console.Write("Print name:");
            string name = Console.ReadLine();

            Console.Write("Print symbol:");
            string symbol = Console.ReadLine();

            Console.Clear();

            string space = " ";

            int rowsCount = 3;
            int columnsCount = name.Length + symbol.Length * 2 + space.Length * 2;

            for (int y = 0; y < rowsCount; y++)
            {
                if (y == 0 || y == rowsCount - 1)
                {
                    for (int x = 0; x < columnsCount; x++)
                    {
                        Console.Write(symbol);
                    }

                    Console.WriteLine();
                } 
                else
                {
                    Console.WriteLine($"{symbol}{space}{name}{space}{symbol}");
                }
            }
        }
    }
}
