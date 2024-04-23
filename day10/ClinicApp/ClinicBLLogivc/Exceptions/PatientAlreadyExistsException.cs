using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClinicBLLogivc
{
    [ExcludeFromCodeCoverage]
    public class PatientAlreadyExistsException : Exception
    {
        string msg = string.Empty;
        public PatientAlreadyExistsException()
        {
            msg = "Patient Already Exists";
        }
        public override string Message => msg;
    }
}