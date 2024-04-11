using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstFrameWorkApp
{

    internal class Program
    {
        static int add(int x, int y)
        {
            return x + y;

        }
        static int subtract(int x, int y)
        {
            return (x - y);
        }
        static int multiply(int x, int y)
        {
            return x * y;
        }
        static int divide(int x, int y)
        {
            return x / y;
        }
        static int reminder(int x, int y)
        {
            return x % y;
        }
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
            Console.WriteLine("Question:\n Create a application that take 2 numbers and find its sum, product and divide the first by second, also supract the second from the first. \nInclude another method to find the remainder when the first number is divided by second\n");
            Console.WriteLine("enter the first number");
            int a, b;
            if (!TryConvertToInt(Console.ReadLine(), out a))
            {
                Console.WriteLine("not a valid number");
                Console.ReadLine(); 
                return; 
            }
            Console.WriteLine("enter the second number");
            if (!TryConvertToInt(Console.ReadLine(), out b))
            {
                Console.WriteLine("not a valid number");
                Console.ReadLine(); 
                return; 
            }
            Console.WriteLine($"The sum of the numbers is {add(b, a)}");
            Console.WriteLine($"The subraction of the numbers is {subtract(b, a)}");
            Console.WriteLine($"The multiplication of the numbers is {multiply(b, a)}");
            Console.WriteLine($"The division of the numbers is {divide(b, a)}");
            Console.WriteLine($"The remainder of the numbers is {divide(a, b)}");
            Console.ReadLine();
        }
    }
}