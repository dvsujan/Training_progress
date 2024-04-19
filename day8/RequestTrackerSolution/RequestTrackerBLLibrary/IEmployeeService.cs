using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    internal interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string employeeName);
        Employee ChangeEmployeeName(string employeeOldName, string employeeNewName);
        Employee ChangeEmployeeDepartment(int employeeId, int departmentId);
    }
}