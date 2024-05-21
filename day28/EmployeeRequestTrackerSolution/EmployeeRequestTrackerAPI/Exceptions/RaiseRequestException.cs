using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class RaiseRequestException : Exception
    {
        public RaiseRequestException()
        {
        }

        public RaiseRequestException(string? message) : base(message)
        {
        }

        public RaiseRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RaiseRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}