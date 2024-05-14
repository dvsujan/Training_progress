namespace EmployeeTrackerApi.Exceptions
{
    public class NoSuchEmployeeException:Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No such employee found";
        }
        public override string Message => message;

    }
}
