using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 11");

            if (args.Count() != 1)
            {
                Console.WriteLine("Wrong number of arguments!");
                Console.WriteLine(args.Count() > 1 ? "Too many inputs, only need 1" : "Too few inputs, need 1");
            }

            var path = args[0];
            int[,] matrix = new int[25,25];
            int counter = 0;


            using (var reader = new StreamReader(path))
            {
                string[] lineValues = new string[20];

                while (!reader.EndOfStream)
                {
                    lineValues = reader.ReadLine().Trim().Split(' ');

                    for (int j = 0; j < lineValues.Count(); j++)
                    {
                        if (!string.IsNullOrEmpty(lineValues[j]))
                        {
                            matrix[counter, j] = Convert.ToInt32(lineValues[j]);
                            
                        }
                    }
                    counter++;
                }
            }

            double greatestProduct = -1;
            string methodUsed = "";
            string candidateMethod = "";
            int greatestI = -1, greatestJ = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    double candidateProduct = -1;

                    candidateProduct = Read(matrix, i, j, out candidateMethod);

                    if (greatestProduct < candidateProduct)
                    {
                        greatestI = i;
                        greatestJ = j;
                        greatestProduct = candidateProduct;
                        methodUsed = candidateMethod;
                    }
                }
            }
            Console.WriteLine("The value of the matrix at the greatest indeces is: "+matrix[greatestI,greatestJ].ToString()+", and used this method: "+methodUsed);
            Console.WriteLine("The greatest Read product uses indeces i," + greatestI.ToString() + " j," + greatestJ.ToString() + " with a product of : " + greatestProduct.ToString());
        }

        static public double Read(int[,] matrix, int indexI, int indexJ, out string methodName)
        {
            double product = 1;
            double candidate = 0;
            string temp = "No method used";

            try
            {
                candidate = ReadLeft(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadLeft used";
                    product = candidate;
                }

                candidate = ReadRight(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadRight used";
                    product = candidate;
                }

                candidate = ReadUp(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadUp used";
                    product = candidate;
                }

                candidate = ReadDown(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadDown used";
                    product = candidate;
                }

                candidate = ReadDiagLeftDown(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadDiagLeftDown used";
                    product = candidate;
                }
                candidate = ReadDiagLeftUp(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadDiagLeftUp used";
                    product = candidate;
                }

                candidate = ReadDiagRightDown(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadDiagRightDown used";
                    product = candidate;
                }

                candidate = ReadDiagRightUp(matrix, indexI, indexJ);

                if (product < candidate)
                {
                    temp = "ReadDiagRightUp used";
                    product = candidate;
                }
                
            }
            catch (Exception e)
            {
                temp = "No method used";
                methodName = temp;
                return -1;
            }

            methodName = temp;
            return product;
        }

        static public double ReadLeft(int[,] matrix, int indexI, int indexJ)
        {
            if (indexJ - 4 < 0)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI, indexJ - counter];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
        static public double ReadRight(int[,] matrix, int indexI, int indexJ)
        {
            if (indexJ + 4 < matrix.Length)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI, indexJ + counter];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
        static public double ReadUp(int[,] matrix, int indexI, int indexJ)
        {
            if (indexI - 4 < 0)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI - counter, indexJ];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
        static public double ReadDown(int[,] matrix, int indexI, int indexJ)
        {
            if (indexI + 4 < matrix.Length)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI + counter, indexJ ];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }

        static public double ReadDiagLeftUp(int[,] matrix, int indexI, int indexJ)
        {
            if (indexI - 4 < 0 || indexJ - 4 < 0)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI - counter, indexJ - counter];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
        static public double ReadDiagLeftDown(int[,] matrix, int indexI, int indexJ)
        {
            if (indexI + 4 < matrix.Length || indexJ - 4 < 0)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI + counter, indexJ - counter];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
        static public double ReadDiagRightUp(int[,] matrix, int indexI, int indexJ)
        {
            if (indexI - 4 < 0 || indexJ + 4 < matrix.Length)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI - counter, indexJ + counter];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
        static public double ReadDiagRightDown(int[,] matrix, int indexI, int indexJ)
        {
            if (indexI + 4 < matrix.Length || indexJ + 4 < matrix.Length)
            {
                return -1;
            }

            double product = 1;

            try
            {
                int counter = 0;
                while (counter < 4)
                {
                    product *= matrix[indexI + counter, indexJ + counter];
                    counter++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

            return product;
        }
    }

    static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 13");

            if (args.Count() != 1)
            {
                Console.WriteLine("Wrong number of arguments!");
                Console.WriteLine(args.Count() > 1 ? "Too many inputs, only need 1" : "Too few inputs, need 1");
                return;
            }

            var path = args[0];
            List<string> num_list = new List<string>();
            int[] temp_int = new int[300];
            char[] reversed_final_num = temp_int.ToString().ToCharArray();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    num_list.Add(reader.ReadLine());
                }

                Console.WriteLine("Read in the input file");

                for (int i = 0; i < num_list.Count; i++)
                {
                    num_list[i] = (string)num_list[i].Reverse();
                }

                int temp = 0, carryover = 0;

                for (int i = 0; i < num_list.Count; i++)
                {
                    char[] temp_char = num_list[i].ToCharArray();

                    for (int j = 0; j < reversed_final_num.Count(); j++) 
                    {
                        temp = Convert.ToInt32(reversed_final_num[j]) + Convert.ToInt32(temp_char[j]) + carryover;
                        carryover = temp / 10;
                        temp = temp % 10;
                        reversed_final_num[j] = Convert.ToChar(temp);
                    }
                }

                string final_answer = reversed_final_num.Reverse().ToString();

                Console.WriteLine("The Final answer is: " + final_answer);
                Console.WriteLine("The first 10 digits are: " + final_answer.Substring(0,10));
            }
        }
}
