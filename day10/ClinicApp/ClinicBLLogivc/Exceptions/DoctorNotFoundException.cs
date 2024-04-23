using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClinicBLLogivc.Exceptions
{   
    [ExcludeFromCodeCoverage]
    public class DoctorNotFoundException : Exception
    {
        string msg;
        public DoctorNotFoundException()
        {
            msg = "Doctor Not Found";

        }
        public override string Message => msg;
        
    }
}