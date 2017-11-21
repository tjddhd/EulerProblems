using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem17
{
    class Program
    {
        const string ONE ="one", TWO ="two", THREE ="three", FOUR ="four", FIVE ="five", SIX ="six", SEVEN ="seven", EIGHT ="eight", NINE ="nine";
        const string TEN ="ten", TWENTY ="twenty", THIRTY ="thirty", FORTY ="forty", FIFTY ="fifty", SIXTY ="sixty", SEVENTY ="seventy", EIGHTY ="eighty", NINETY ="ninety";
        const string ELEVEN ="eleven", TWELVE ="twelve", THIRTEEN ="thirteen", FOURTEEN ="fourteen", FIFTEEN ="fifteen", SIXTEEN ="sixteen", SEVENTEEN ="seventeen", EIGHTEEN ="eighteen", NINETEEN ="nineteen";
        const string HUNDRED ="hundred", THOUSAND ="thousand", AND ="and";

        const int MAX = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine("This is Problem 17");

            string[] num_names = new string[MAX];
            double sum = 0;

            for (int j = 1; j <= MAX; j++)
            {
                num_names[j -1] = convertToString(j);
            }

            for (int k = 0; k < num_names.Count(); k++)
            {
                //Console.WriteLine(num_names[k]);
                sum += num_names[k].Length;
            }

            Console.WriteLine("The combined length for the numbers 1 through " + MAX +" is: " + sum);
        }

        static public string convertToString(int i)
        {
            string temp ="";
            bool somethingBeforeTens = false;

            if (i / 1000 > 0)
            {
                temp = temp + convertDigit(i / 1000) + THOUSAND;
                i -= (i / 1000)*1000;
                somethingBeforeTens = true;
            }

            if (i / 100 > 0)
            {
                temp = temp + convertDigit(i / 100) + HUNDRED;
                i -= (i / 100) * 100;
                somethingBeforeTens = true;
            }

            if (i == 0)
                return temp.Trim();

            temp = temp + (somethingBeforeTens ? AND :"") + convertTensDigit(i);

            return temp.Trim();
        }

        static public string convertDigit(int i)
        {
            string temp ="";

            switch(i)
            {
                case(1):
                    temp = ONE;
                    break;
                case(2):
                    temp = TWO;
                    break;
                case(3):
                    temp = THREE;
                    break;
                case (4):
                    temp = FOUR;
                    break;
                case (5):
                    temp = FIVE;
                    break;
                case (6):
                    temp = SIX;
                    break;
                case (7):
                    temp = SEVEN;
                    break;
                case (8):
                    temp = EIGHT;
                    break;
                case (9):
                    temp = NINE;
                    break;
            }

            return temp;
        }

        static private string convertTensDigit(int i)
        {
            string temp ="";


            if (i >= 10)
            {
                int j = i % 10;
                i = i / 10;
                
                switch (i)
                {
                    case (1):
                        switch (j)
                        {
                            case (0):
                                temp = TEN;
                                break;
                            case (1):
                                temp = ELEVEN;
                                break;
                            case (2):
                                temp = TWELVE;
                                break;
                            case (3):
                                temp = THIRTEEN;
                                break;
                            case (4):
                                temp = FOURTEEN;
                                break;
                            case (5):
                                temp = FIFTEEN;
                                break;
                            case (6):
                                temp = SIXTEEN;
                                break;
                            case (7):
                                temp = SEVENTEEN;
                                break;
                            case (8):
                                temp = EIGHTEEN;
                                break;
                            case (9):
                                temp = NINETEEN;
                                break;
                        }
                        break;
                    case (2):
                        temp = TWENTY + convertDigit(j);
                        break;
                    case (3):
                        temp = THIRTY + convertDigit(j);
                        break;
                    case (4):
                        temp = FORTY + convertDigit(j);
                        break;
                    case (5):
                        temp = FIFTY + convertDigit(j);
                        break;
                    case (6):
                        temp = SIXTY + convertDigit(j);
                        break;
                    case (7):
                        temp = SEVENTY + convertDigit(j);
                        break;
                    case (8):
                        temp = EIGHTY + convertDigit(j);
                        break;
                    case (9):
                        temp = NINETY + convertDigit(j);
                        break;
                }
            }
            else
            {
                temp = convertDigit(i);
            }

            return temp;
        }
    }
}
