using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem21
{
    class Program
    {
        static void Main(string[] args)
        {

            /// Welcome message with generic program details ///
            String probNum = "21";
            String probURL = "https://projecteuler.net/problem=21";
            double result = 0;

            Console.WriteLine($"\nHello and welcome to the executable for Euler Problem {probNum}!");
            Console.WriteLine($"Details for this problem can be found here: {probURL} \n\n");


            /// Start program logic ///
            double upperLimit;
            Dictionary<int, int> dictAmicablePairs = new Dictionary<int, int>();

            Console.WriteLine($"Please note that for next prompt, the program will round numbers up if the input is not whole.\n");

            Console.WriteLine($"Please enter a number to upper limit for the factorial number search: ");
            if (double.TryParse(Console.ReadLine(), out upperLimit))
            {
                Console.WriteLine($"Starting amicable number search using user provided upper limit of {upperLimit}...\n");
                findAmicablePairs(out dictAmicablePairs, upperLimit);
                Console.WriteLine($"The search completed. {dictAmicablePairs.Count()} amicable pairs were found.\n\n");


                Console.WriteLine($"Computing sum of the amicable pairs previously found...\n");
                foreach (KeyValuePair<int,int> amicablePair in dictAmicablePairs)
                    result += amicablePair.Key + amicablePair.Value;
                Console.WriteLine($"The summation has completed. The result is: {result}\n\n");
            }
            else
            {
                Console.WriteLine($"An invalid input was given. Please enter a number when prompted. The program will now end.");
                return;
            }

            /// End pragram logic ///


            // Ending message with result of program execution ///

            Console.WriteLine($"\n\nThe final answer for the problem is: {result}");
            Console.WriteLine($"Ending program execution, Goodbye!");

        }


        /// <summary>
        /// Finds the amicable number pairs between 1 and the provided upper limit
        /// </summary>
        /// <param name="results">Dictionary of the amicable pairs that are found</param>
        /// <param name="upperLimit">Provided upper limit to look through</param>
        public static void findAmicablePairs(out Dictionary<int, int> results, double upperLimit)
        {
            results = new Dictionary<int, int>();

            //The loop will start at 1 and search through the upper limit
            //Inner loop is designed to only look through current index up to upper limit, does not look lower
            //This prevents double processing of already calculated potential pairs

            for(int index = 1; index <= upperLimit; index++)
            {
                for(int innerIndex = index + 1; innerIndex <= upperLimit; innerIndex++)
                {
                    if(!results.ContainsKey(index)  && !results.ContainsKey(innerIndex) && isAmicablePair(index, innerIndex))
                    {
                        results.Add(index,innerIndex);
                    }
                }
            }

        }

        /// <summary>
        /// Determines if the candidate pair is an amicable number pair
        /// </summary>
        /// <param name="x">Candidate number 1</param>
        /// <param name="y">Candidate number 2</param>
        /// <returns>Boolean with determination if candidates are amicable number pair</returns>
        public static bool isAmicablePair(int x, int y)
        {
            bool result = false;
            List<int> factorsX = new List<int>(), factorsY = new List<int>();
            int sumXFactors = 0, sumYFactors = 0;


            factorsX = ComputeFactors(x);
            factorsY = ComputeFactors(y);


            foreach (int xFactor in factorsX)
                sumXFactors += xFactor;
            foreach (int yFactor in factorsY)
                sumYFactors += yFactor;


            result = (sumXFactors == y) && (sumYFactors == x);


            return result;
        }

        /// <summary>
        /// Computes the whole factors of a given input
        /// </summary>
        /// <param name="x">Input to factor</param>
        /// <returns>List of factors</returns>
        public static List<int> ComputeFactors(int x)
        {
            List<int> result = new List<int>();

            result.Add(1);

            for(int counter = 2; counter < x; counter++)
            {
                if(x % counter == 0 && !result.Contains(counter))
                {
                    result.Add(counter);
                }
            }

            return result;
        }
    }
}
