using System.Runtime.InteropServices;

namespace CardValidation
{
    internal class Program
    {
        static bool IsValidNumber(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a 16-digit number:");
            string input = Console.ReadLine();
            string reversed = String.Empty;

            if (input == null)
            {
                Console.WriteLine("not a valid string");
                return; 
            }
            
            for(int i = input.Length - 1; i> -1; i--)
            {
                reversed += input[i]; 
            }
            
            if (input.Length != 16 || !IsValidNumber(input))
            {
                Console.WriteLine("Invalid input. Please enter a 16-digit number.");
                return;
            }
            
            Console.WriteLine(reversed);
            int sum = 0;

            for (int i = 0; i < reversed.Length; i++)
            {
                int digit = int.Parse(reversed[i].ToString());

                if ((i+1) % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = (digit % 10) + (digit / 10);
                    }
                }
                sum += digit;
            }

            bool isValid = sum % 10 == 0;
            if(isValid)
            {
                Console.WriteLine("Given Number is a valid Card");
            }
            else
            {
                Console.WriteLine("Given number is not a valid card Number");
            }
        }
    }
}
