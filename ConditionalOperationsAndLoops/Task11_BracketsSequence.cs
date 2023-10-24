using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task11
{
    internal class BracketsSequence
    {
        public static void Main(string[] args)
        {
            // не бейте за комментарий, я оставил на случай тестов
            //string testCase1 = "(()(()))";
            //string testCase2 = "(()";
            //string testCase3 = "(()))(()";
            //string testCase4 = ")(";

            Console.WriteLine($"Print brackets sequence:");

            string bracketsInput = Console.ReadLine();

            int maxDepth = 0;
            int curDepth = 0;

            for (int i = 0; i < bracketsInput.Length && curDepth >= 0; i++)
            { 
                if (bracketsInput[i] == '(' )
                {
                    curDepth++;
                } 
                else if (bracketsInput[i] == ')' )
                {
                    curDepth--;
                }

                if (curDepth > maxDepth)
                {
                    maxDepth = curDepth;
                }
            }

            if (curDepth == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sequence is valid");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sequence is invalid");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"Max depth: {maxDepth}");
        }
    }
}
