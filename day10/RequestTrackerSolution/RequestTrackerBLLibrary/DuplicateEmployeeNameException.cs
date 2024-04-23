using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    [Serializable]
    internal class DuplicateEmployeeNameException : Exception
    {
        string msg; 
        public DuplicateEmployeeNameException()
        {
            msg = "Employee name already exists";
        }
        public override string Message => msg;
        
    }
}