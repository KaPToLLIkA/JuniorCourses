using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task8
{
    internal class PasswordApp
    {
        public static void Main(string[] args)
        {
            string password = "12345678";

            int availableAttempts = 3;

            for (int i = 0; i < availableAttempts; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter password to continue:");
                Console.ForegroundColor = ConsoleColor.White;

                string inputPassword = Console.ReadLine();

                if (inputPassword == password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Access allowed.");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Secret: You've been lied to all your life, the earth is flat.");
                    
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Access dinied.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine("power off");
        }
    }
}
