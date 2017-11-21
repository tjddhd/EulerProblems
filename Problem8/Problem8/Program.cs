using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 8");
            int numDigits = 13;
            string numberToParse = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        
            char[] numberArray = numberToParse.ToArray();
            double greatestProduct = 0;

            for (int i = 0; i < numberArray.Count(); i++)
            {
                Console.WriteLine("Iteration number: " + i.ToString());
                if (i + numDigits >= numberArray.Count())
                    break;

                int[] numbersToMultiply = new int[numDigits];

                for (int j = i; j < i + numDigits; j++)
                {
                    numbersToMultiply[j - i] = int.Parse(numberArray[j].ToString());
                    //Console.WriteLine("This was assigned to numbersToMultiply: " + numbersToMultiply[j-i].ToString());
                    //Console.WriteLine("The digit is: " + numberArray[j]);
                }

                double temp = 1;
                for (int k = 0; k < numbersToMultiply.Count(); k++)
                {
                    temp *= numbersToMultiply[k];
                    //Console.WriteLine("I multiplied the product by: " + numbersToMultiply[k]);
                    //Console.WriteLine("Current Product: "+temp.ToString());
                }

                if (temp > greatestProduct)
                    greatestProduct = temp;
                Console.WriteLine("The Product of this iteration's number is: " + temp.ToString());
            }

            Console.WriteLine("The Greatest Product is : " + greatestProduct.ToString());
        }
    }
}
