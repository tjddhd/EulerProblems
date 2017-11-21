using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 7");

            int max = 1000000;

            bool[] vals = new bool[max];

            for (int i = 0; i < max; i++)
                vals[i] = true;

            for (int i = 2; i < Math.Sqrt(max); i++)
            {
                //Console.WriteLine("Inside i loop: "+i.ToString());
                if (vals[i])
                {
                    for (int j = 1; j < max; j++)
                    {
                        //Console.WriteLine("Inside j loop" + j.ToString());
                        for (int k = i * i; k < max; k = k + j * i)
                        {
                            //Console.WriteLine("Inside k loop" + k.ToString());
                            vals[k] = false;
                        }
                    }
                }
            }

            int count = -1;
            for (int i = 0; i < max; i++)
            {
                if (vals[i])
                {
                    Console.WriteLine("Prime index: " + count.ToString() + ", Number is: " + i.ToString());
                    count++;
                    if (count == 10002)
                        return;
                }
            }
        }
    }
}
