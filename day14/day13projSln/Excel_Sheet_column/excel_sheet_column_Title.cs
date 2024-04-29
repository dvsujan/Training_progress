using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13proj
{
     public class excel_sheet_column_Title
    {
        public static async Task<string> NumberToColumn(int n)
        {
            string st = String.Empty;
            while (n > 0)
            {
                n--;
                st = (char)('A' + n % 26) + st;
                n /= 26;
            }
            return st;
        }
        public static async Task Main(string[] args)
        {
            Console.WriteLine("enter a number");
            int n; 
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Please enter a valid number");
            }
            Console.WriteLine(await NumberToColumn(n));
        }
    }
}
