using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Welcome message with generic program details ///
            String probNum = "20";
            String probURL = "https://projecteuler.net/problem=20";
                
            Console.WriteLine($"\nHello and welcome to the executable for Euler Problem {probNum}!");
            Console.WriteLine($"Details for this problem can be found here: {probURL} \n\n");


            /// Start program logic ///

            double factorialNum, digitSummaitonResult;
            BigInteger factorialResult;

            Console.WriteLine($"Please note that for next prompt, the program will round numbers up if the input is not whole.\n");

            Console.WriteLine($"Please enter a number to first get factorial of, then add the digits of the resultant factorial: ");
            if(double.TryParse(Console.ReadLine(), out factorialNum))
            {
                Console.WriteLine($"Computing the Factorial of input '{factorialNum}'...\n");
                factorialResult = ComputeFactorial(Math.Ceiling(factorialNum));
                Console.WriteLine($"The result was calculated to be: {factorialResult}\n\n");

                Console.WriteLine($"Computing the Summaiton of the Factorial Digits for {factorialResult}...\n");
                digitSummaitonResult = ComputeDigitSum(factorialResult);
                Console.WriteLine($"The result was calculated to be: {digitSummaitonResult}\n\n");
            }
            else
            {
                Console.WriteLine($"An invalid input was given. Please enter a number when prompted. The program will now end.");
                return;
            }

            /// End pragram logic ///


            // Ending message with result of program execution ///

            Console.WriteLine($"\n\nThe final answer for the problem is: {digitSummaitonResult}");
            Console.WriteLine($"Ending program execution, Goodbye!");
        }

        /// <summary>
        /// Gets a numerical input and computes the factorial of that number
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>Factorial of input</returns>
        public static BigInteger ComputeFactorial(double input)
        {
            BigInteger result = 1;

            for(int i = 1; i <= input; i++)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// Gets a numerical input and computes the summation of the digits
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>Digit summation of input</returns>
        public static double ComputeDigitSum(BigInteger input)
        {
            double result = 0;
            char[] digits = input.ToString().ToCharArray();

            foreach(char digit in digits)
            {
                int digitValue;
                if(int.TryParse(digit.ToString(), out digitValue))
                {
                    result += digitValue;
                }
            }

            return result;
        }
    }
}
