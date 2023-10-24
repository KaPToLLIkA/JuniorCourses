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
            Console.WriteLine($"Print brackets sequence:");

            string bracketsInput = Console.ReadLine();

            int maxDepth = 0;
            int currrentDepth = 0;

            for (int i = 0; i < bracketsInput.Length; i++)
            { 
                if (bracketsInput[i] == '(' )
                {
                    currrentDepth++;

                    if (currrentDepth > maxDepth)
                    {
                        maxDepth = currrentDepth;
                    }
                } 
                else if (bracketsInput[i] == ')' )
                {
                    currrentDepth--;

                    if (currrentDepth <= 0)
                    {
                        break;
                    }
                }
            }

            if (currrentDepth == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sequence is valid");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Max depth: {maxDepth}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sequence is invalid");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
