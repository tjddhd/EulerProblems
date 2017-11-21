using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 9");

            decimal a = 0, b = 0, c = 0;
            bool isPythagTriple = true;

            for (int n = 1; n < 1000; n++)
            {
                for (int m = 2; m < 1000; m++)
                {
                    a = (m * m) - (n * n);
                    b = 2 * m * n;
                    c = (m * m) + (n * n);

                    isPythagTriple = ((a * a) + (b * b) == (c * c));

                    if (!isPythagTriple)
                        break;
                    
                    if (isPythagTriple && (a + b + c == 1000))
                    {
                        Console.WriteLine("The Accetable Pythagorean Triple is: a," + a.ToString() + " b," + b.ToString() + " c," + c.ToString());
                        Console.WriteLine("The Product of these numbers  is: " + (a*b*c).ToString());
                        return;
                    }

                    isPythagTriple = false;
                }
            }

        }
    }
}
