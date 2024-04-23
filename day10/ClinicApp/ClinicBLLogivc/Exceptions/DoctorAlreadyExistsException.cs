using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClinicBLLogivc.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DoctorAlreadyExistsException : Exception
    {
        string msg;
        public DoctorAlreadyExistsException()
        {
            msg = "Doctor Already Exists";

        }
        public override string Message => msg;
        
    }
}