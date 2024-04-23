using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

namespace ClinicBLLogivc.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class AppointmentNotFoundException : Exception
    {
        string msg = String.Empty; 
        public AppointmentNotFoundException()
        {
            msg = "Appointment Not Found"; 
        }
        public override string Message => msg; 

    }
}