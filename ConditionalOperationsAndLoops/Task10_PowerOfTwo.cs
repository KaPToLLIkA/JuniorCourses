using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task10
{
    internal class PowerOfTwo
    {
        public static void Main(string[] args)
        {
            int minRandom = 1;
            int maxRandom = 65536;

            Random random = new Random();
            int value = random.Next(minRandom, maxRandom);

            int power = 0;
            int powerOfTwo = 1;
            int multiplier = 2;

            while (powerOfTwo < value)
            {
                powerOfTwo *= multiplier;
                power++;
            }

            Console.WriteLine($"Value: {value}\nResult: 2^{power} = {powerOfTwo}");
        }
    }
}
