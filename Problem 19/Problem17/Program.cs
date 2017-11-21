using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Project Euler Problem, Problem 19
 * 
 * Prompt:
 * 
 * You are given the following information, but you may prefer to do some research for yourself.
•1 Jan 1900 was a Monday.
•Thirty days has September,
 April, June and November.
 All the rest have thirty-one,
 Saving February alone,
 Which has twenty-eight, rain or shine.
 And on leap years, twenty-nine.
•A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

 * 
 * */

namespace Problem19
{
    class Program
    {
        const int JAN = 31, FEB = 28, MAR = 31, APR = 30, MAY = 31, JUN = 30, JUL = 31, AUG = 31, SEP = 30, OCT = 31, NOV = 30, DEC = 31;
        static int result;

        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 19");

            if (args.Count() != 1)
            {
                Console.WriteLine("Please provide the correct number of arguments\n\tEnd Year");
            }
            else if (!int.TryParse(args[0], out result))
            {
                Console.WriteLine("Please provide the numeric argument\n\tEnd Year");
            }
            else if (result < 1900)
            {
                Console.WriteLine("Please provide a numeric year great than 1900\n\tEnd Year");
            }
            else
            {
                DateTime currentDay = new DateTime(1900,1,1);
                int countSundaysFirstOfMonth = 0;

                Console.WriteLine("Current Day of Jan 1, 1900 is " + currentDay.DayOfWeek);

                for (int j = 1900; j <= result; j++)
                {
                    for (int k = 1; k <= 12; k++)
                    {
                        int month = determineMonth(k, j);
                        for (int i = 1; i <= month; i++)
                        {
                            //Console.WriteLine("Month {0}, Day {1} is a {2}", k, i, currentDay.DayOfWeek);

                            if (i == 1 && currentDay.DayOfWeek == DayOfWeek.Sunday && j > 1900)
                            {
                                countSundaysFirstOfMonth++;
                                Console.WriteLine("Number of sundays increased! Year {0}, Month {1}, Sunday number {2}", j, k, countSundaysFirstOfMonth);
                            }

                            currentDay = currentDay.AddDays(1);
                        }
                    }
                }

                Console.WriteLine("The number of times the 1st of the month fell on a Sunday between beginning of 1901 and end of {0} is {1}", result, countSundaysFirstOfMonth);
            }

        }

        static public int determineMonth(int numDesignation, int year)
        {
            int retData = 0;
            switch (numDesignation)
            {
                case 1:
                    retData = JAN;
                    break;
                case 2:
                    retData = year % 4 == 0 ? (year % 100 == 0 && year % 400 != 0 ? FEB : FEB + 1) : FEB;
                    break;
                case 3:
                    retData = MAR;
                    break;
                case 4:
                    retData = APR;
                    break;
                case 5:
                    retData = MAY;
                    break;
                case 6:
                    retData = JUN;
                    break;
                case 7:
                    retData = JUL;
                    break;
                case 8:
                    retData = AUG;
                    break;
                case 9:
                    retData = SEP;
                    break;
                case 10:
                    retData = OCT;
                    break;
                case 11:
                    retData = NOV;
                    break;
                case 12:
                    retData = DEC;
                    break;
                default:
                    break;
            }
            return retData;
        }
    }
}
