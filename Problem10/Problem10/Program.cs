using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 10");

            double sum = 0;

            for (double j = 2; j < 2000000; j++)
            {
                int temp = 2;
                bool isPrime = true;

                while (temp < j)
                {
                    if (j % temp == 0)
                    {
                        isPrime = false;
                        temp = Convert.ToInt32(j);
                    }
                    temp++;
                }

                if (isPrime)
                {
                    sum += j;
                    Console.WriteLine("Made it to index: " + j.ToString());
                }
            }
            Console.WriteLine("The answer is: "+sum.ToString());
        }
    }
}
