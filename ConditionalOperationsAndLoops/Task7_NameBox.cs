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
            char symbol = (char)Console.Read();

            Console.Clear();

            string middleRow = $"{symbol} {name} {symbol}";
            string headerAndFooter = new(symbol, middleRow.Length);

            Console.Write($"\n{headerAndFooter}\n{middleRow}\n{headerAndFooter}");
        }
    }
}
