using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClinicBLLogivc.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class AppointmentAlreadyExistsException : Exception
    {
        string msg = string.Empty;
        public AppointmentAlreadyExistsException()
        {
            msg = "Appointment Already Exists";
        }
        public override string Message => msg;
        
    }
}