using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace ClinicModelLibrary
{
    internal class RandomId
    {
        [ExcludeFromCodeCoverage]
        public static int GenerateInt()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        [ExcludeFromCodeCoverage]
        public static string GenerateString()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }
        [ExcludeFromCodeCoverage]
        public static string GenerateAlphaNumeric()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString() + random.Next(1000, 9999).ToString();
        }
    }
}