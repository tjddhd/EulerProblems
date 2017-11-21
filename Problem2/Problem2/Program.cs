using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This is Problem 2");

            double term1 = 1;
            double term2 = 2;
            double sum = 0;

            while (term2 < 4000000)
            {
                if(term2 % 2 == 0)
                    sum += term2;

                double temp = term2;
                term2 += term1;
                term1 = temp;
            }

            Console.WriteLine("The answer is: " + sum.ToString());
        }
    }
}
