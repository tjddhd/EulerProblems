using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 3");

            double numberToFactor = 600851475143;
            
            //double[] factors = new double[400000];
            //double index = 0;

            double largestPrimeFactor = 0;
            bool NotPrime = false;

            for (int i = 2; i <= Math.Sqrt(numberToFactor); i++)
            {
                
                if (numberToFactor % i == 0)
                {
                    for (int j = 2; j <= Math.Sqrt(numberToFactor) && !NotPrime; j++)
                    {
                        if (i % j == 0 && i != j)
                        {
                            NotPrime = true;
                        }
                    }
                    

                    if (!NotPrime)
                    {
                        largestPrimeFactor = largestPrimeFactor > i ? largestPrimeFactor : i;
                    }

                    NotPrime = false;
                    numberToFactor = numberToFactor / i;
                    i = 2;
                }
            }

            //this took way too long to run

            //Console.WriteLine("made it into factors loop");
            //for (double i = 0; i < Math.Sqrt(numberToFactor); i++)
            //{
            //    if (numberToFactor % i == 0)
            //    {
            //        factors[Convert.ToInt32(index)] = i;
            //        index++;
            //    }

            //    if (i % 10000000 == 0)
            //        Console.WriteLine("Made it to index: " + i.ToString());
            //}

            //Console.WriteLine("made it inot prime factors loop");
            //for (double j = 0; j < index; j++)
            //{
            //   int temp = 2;
            //   bool isPrime = true;

            //   while (temp < factors[Convert.ToInt32(j)])
            //   {
            //       if (factors[Convert.ToInt32(j)] % temp == 0)
            //       {
            //           isPrime = false;
            //       }
            //       temp++;
            //   }

            //   if (isPrime)
            //       largestPrimeFactor = factors[Convert.ToInt32(j)];

            //   if (j % 10000000 == 0)
            //       Console.WriteLine("Made it to index: " + j.ToString());
            //}

            largestPrimeFactor = numberToFactor; //this is now prime

            Console.WriteLine("The largest prime number is: " + largestPrimeFactor.ToString());
        }
    }
}
