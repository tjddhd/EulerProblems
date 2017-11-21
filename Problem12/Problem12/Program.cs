using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 12");
            int triangleNum = 0;

            for (int i = 1; i < int.MaxValue; i++)
            {
                triangleNum += i;
                //Console.WriteLine("The current Traingle Number: " + triangleNum.ToString());

                int countDivisors = 0;
                for (int j = 1; j < Math.Sqrt(triangleNum); j++)
                {
                    if (triangleNum % j == 0)
                        countDivisors += 2;
                }
                //Console.WriteLine("The Number of Divisors is: " + countDivisors.ToString());

                if (countDivisors >= 500)
                {
                    Console.WriteLine("The answer is: " + triangleNum.ToString());
                    return;
                }
            }
        }
    }
}
