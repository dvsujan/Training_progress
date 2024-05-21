using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class UnableToGetRequestsException : Exception
    {
        public override string Message => "unable to get messages";
    }
}