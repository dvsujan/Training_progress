using System;
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
            Console.WriteLine("Question:\ncreate an application that will find the greatest of the given numbers. Take input until the user enters a negative number\r\n");
            Console.WriteLine("enter the Numbers below");
            int max = -1;
            while (true)
            {
                int x; 
                if(!TryConvertToInt(Console.ReadLine(), out x))
                {
                    Console.WriteLine("not a valid number");
                }
                else
                {
                    if (x < 0)
                    {
                        break;
                    }
                    if (x > max)
                    {
                        max = x;
                    }
                }
            }
            Console.WriteLine($"The greatest number given is {max}");
            Console.ReadLine();
        }
    }
}