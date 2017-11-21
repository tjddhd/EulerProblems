using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem13
{
    class Program
    {
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
            //int[] temp_int = new int[300];
            char[] reversed_final_num = new char[300];

            for (int k = 0; k < reversed_final_num.Count(); k++)
            {
                reversed_final_num[k] = '0';
            }

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    num_list.Add(reader.ReadLine());
                }

                Console.WriteLine("Read in the input file");

                for (int i = 0; i < num_list.Count; i++)
                {

                    num_list[i] = string.Concat(Enumerable.Reverse(num_list[i]));
                }

                //Console.WriteLine("num elemnets: " + reversed_final_num.Count());

                int temp = 0, carryover = 0;

                for (int i = 0; i < num_list.Count; i++)
                {
                    char[] temp_char = num_list[i].ToCharArray();

                    for (int j = 0; j < reversed_final_num.Count(); j++)
                    {
                        int tc = j > temp_char.Count()-1 ? 0 : int.Parse(temp_char[j].ToString());
                        //if (j == 0 & i == 0) Console.WriteLine("this is the inital tc:" + tc);
                        //if (j == 0 & i == 0) Console.WriteLine("this is the inital rfn:" + int.Parse(reversed_final_num[j].ToString()));
                        //if (j == 0 & i == 0) Console.WriteLine("this is the inital carryover:" + carryover);
                        //if (j == 1 & i == 1) Console.WriteLine("this is the inital tc:" + tc);
                        //if (j == 1 & i == 1) Console.WriteLine("this is the inital rfn:" + int.Parse(reversed_final_num[j].ToString()));
                        //if (j == 1 & i == 1) Console.WriteLine("this is the inital carryover:" + carryover);
                        temp = int.Parse(reversed_final_num[j].ToString()) + tc + carryover;
                        //if (j == 0 & i == 0) Console.WriteLine("this is the first temp:" + temp);
                        //if (j == 1 & i == 1) Console.WriteLine("this is the first temp:" + temp);
                        carryover = temp / 10;
                        temp = temp % 10;
                        //if (j == 0 & i == 0) Console.WriteLine("this is the final temp:" + temp);
                        //if (j == 0 & i == 0) Console.WriteLine("this is the carryover:" + carryover);
                        //if (j == 1 & i == 1) Console.WriteLine("this is the final temp:" + temp);
                        //if (j == 1 & i == 1) Console.WriteLine("this is the carryover:" + carryover);
                        reversed_final_num[j] = Char.Parse(temp.ToString());
                        //if (j == 0 & i == 0) Console.WriteLine("this is the char written:" + reversed_final_num[j]);
                        //if (j == 1 & i == 1) Console.WriteLine("this is the char written:" + reversed_final_num[j]);
                    }

                    carryover = 0;
                    temp = 0;
                }

                string final_answer = string.Concat(Enumerable.Reverse(reversed_final_num)).TrimStart('0');

                Console.WriteLine("The Final answer is: " + final_answer);
                Console.WriteLine("The first 10 digits are: " + final_answer.Substring(0, 10));
            }
        }
    }
}
