using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    [Serializable]
    internal class EmployeeNotFoundException : Exception
    {
        string msg; 
        public EmployeeNotFoundException()
        {
            msg = "Employee not found";
        }
        public override string Message => msg;
    }
}