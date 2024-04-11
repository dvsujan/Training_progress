using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;


namespace FirstFrameWorkApp
{

    internal class Program
    {
        static bool TryConvertToInt(string input, out int result)
        {
            result = 0;
            if (input != null)
            {
                if (int.TryParse(input, out int parsedValue))
                {
                    result = parsedValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Question\nFind the avearage of all the numbers that are divisible by 7. Take input until the user enters a negative number\r\n");
            int sum = 0;
            int totalnums = 0;
            Console.WriteLine("Enter the numbers below:");
            while (true)
            {
                int x;
                if (!TryConvertToInt(Console.ReadLine(), out x))
                {
                    Console.WriteLine("not a valid number");
                }
                else
                {
                    if (x < 0)
                    {
                        break;
                    }
                    if (x % 7 == 0)
                    {
                        sum += x;
                        totalnums += 1;
                    }
                }
            }
            Console.WriteLine("the average of numbers divisible by  7 is " + (sum / totalnums));
        }
    }
}