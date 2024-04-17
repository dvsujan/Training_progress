using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    internal class RandomId
    {
        public static int GenerateInt()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        public static string GenerateString()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }
        public static string GenerateAlphaNumeric()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString() + random.Next(1000, 9999).ToString();
        }
    }
}
