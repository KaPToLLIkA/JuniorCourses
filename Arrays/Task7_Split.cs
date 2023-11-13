using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task7
{
    internal class Split
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Print text:");

            string input = Console.ReadLine();

            string blacklist = ",.!;:?\'\"()[]{}";
            char separator = ' ';

            foreach (char blacklistedCharacter in blacklist)
            {
                input = input.Replace(blacklistedCharacter.ToString(), "");
            }

            string[] words = input.Split(separator);
            
            foreach (string word in words)
            {
                Console.WriteLine($"{word}");
            }
        }
    }
}
