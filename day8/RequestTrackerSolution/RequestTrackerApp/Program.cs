
using RequestTrackerBLLibrary;
using RequestTrakerModelLibrary;
using System.Collections;
using System.Globalization;
using RequestTrackerBLLibrary;  

namespace RequestTrackerApp
{
    public class Program
    {
        static DepartmentBL dbl = new DepartmentBL(); 
        static  EmployeeBL ebl = new EmployeeBL(); 
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Change Department Name");
                Console.WriteLine("3. Get Department By Id");
                Console.WriteLine("4. Get Department By Name");
                Console.WriteLine("5. Add Employee");
                Console.WriteLine("6. Change Employee Department");
                Console.WriteLine("7. Change Employee Name");
                Console.WriteLine("8. Get Employee By Id");
                Console.WriteLine("9. Get Employee By Name");
                Console.WriteLine("10. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddDepartment();
                        break;
                    case 2:
                        ChangeDepartmentName();
                        break;
                    case 3:
                        GetDepartmentById();
                        break;
                    case 4:
                        GetDepartmentByName();
                        break;
                    case 5:
                        AddEmployee();
                        break;
                    case 6:
                        ChangeEmployeeDepartment();
                        break;
                    case 7:
                        ChangeEmployeeName();
                        break;
                    case 8:
                        GetEmployeeById();
                        break;
                    case 9:
                        GetEmployeeByName();
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 10); 
        }

        

        private static void AddDepartment()
        {
            try
            {
                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = dbl.AddDepartment(department);
                Console.WriteLine("Department added with id " + id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ChangeDepartmentName()
        {
            try
            {
                Console.WriteLine("Enter department name to edit");
                string oldName = Console.ReadLine();
                Console.WriteLine("Enter new department name");
                string newName = Console.ReadLine();
                Department newDepartment = dbl.ChangeDepartmentName(oldName, newName);
                Console.WriteLine("Department name changed to " + newDepartment.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetDepartmentById()
        {
            try
            {
                Console.WriteLine("enter department id to get details");
                int departmentId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(dbl.GetDepartmentById(departmentId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void GetDepartmentByName()
        {
            try
            {
                Console.WriteLine("enter department name to get details");
                string departmentName = Console.ReadLine();
                Console.WriteLine(dbl.GetDepartmentByName(departmentName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void AddEmployee()
        {
            try
            {
                Console.WriteLine("Enter department name");
                string departmentName = Console.ReadLine();
                Department department = dbl.GetDepartmentByName(departmentName);
                Console.WriteLine("Enter employee name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter employee date of birth");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter employee role");
                string role = Console.ReadLine();
                Employee employee = new Employee() { Name = name, DateOfBirth = dateOfBirth, Role = role, EmployeeDepartment = department };
                int id = ebl.AddEmployee(employee);
                Console.WriteLine("Employee added with id " + id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void GetEmployeeByName()
        {
            try
            {
                Console.WriteLine("Enter employee name to get details");
                string employeeName = Console.ReadLine();
                Console.WriteLine(ebl.GetEmployeeByName(employeeName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        private static void GetEmployeeById()
        {
            try
            {
                Console.WriteLine("Enter employee id to get details");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(ebl.GetEmployeeById(employeeId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ChangeEmployeeName()
        {
            try
            {
                Console.WriteLine("Enter employee name to edit");
                string oldName = Console.ReadLine();
                Console.WriteLine("Enter new employee name");
                string newName = Console.ReadLine();
                Employee newEmployee = ebl.ChangeEmployeeName(oldName, newName);
                Console.WriteLine("Employee name changed to " + newEmployee.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ChangeEmployeeDepartment()
        {
            try
            {
                Console.WriteLine("Enter employee id");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter department id");
                int departmentId = Convert.ToInt32(Console.ReadLine());
                Employee employee = ebl.ChangeEmployeeDepartment(employeeId, departmentId);
                Console.WriteLine("Employee department changed to " + employee.EmployeeDepartment.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


}
