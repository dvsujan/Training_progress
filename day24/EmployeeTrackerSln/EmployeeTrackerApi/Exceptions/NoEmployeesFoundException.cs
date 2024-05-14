namespace EmployeeTrackerApi.Exceptions
{
    public class NoEmployeesFoundException:Exception
    {
        string message;
        public NoEmployeesFoundException()
        {
            message = "No employees found";
        }
        public override string Message => message;
    }
}
