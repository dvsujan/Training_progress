using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClinicBLLogivc
{
    [ExcludeFromCodeCoverage]
    public class PatientNotFoundException : Exception
    {
        string msg; 
        public PatientNotFoundException()
        {
             msg = "Patient Not Found";

        }
        public override string Message => msg;
    }
}