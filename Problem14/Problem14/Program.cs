using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 14");

            long count_answer = 0, index_answer = 0;

            for (long i = 1; i <= 1000000; i++)
            {
                long temp = i, temp_count = 0;
                while (temp != 1)
                {
                    if (temp % 2 == 0)
                    {
                        temp /= 2;
                    }
                    else
                    {
                        temp = 3 * temp + 1;
                    }

                    temp_count++;
                }

                if (count_answer < temp_count)
                {
                    count_answer = temp_count;
                    index_answer = i;
                    Console.WriteLine("New longest length: " + count_answer);
                    Console.WriteLine("New index: " + index_answer);
                }
            }

            Console.WriteLine("The highest number of steps is: " + count_answer);
            Console.WriteLine("The index with the highest steps is: " + index_answer);
        }
    }
}
