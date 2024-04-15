using static System.Runtime.InteropServices.JavaScript.JSType;
using RequestTrackerModelLibrary;
using Microsoft.VisualBasic;
using System.Reflection;
using System;

namespace RequestTrackerDay5
{
    internal class Program
    {
        // Create the model
        // Create methdos for CRUD
        //---MEthods to build employee
        //---Method to add all emploeyes(dependednt on Build employee)
        //---Method to print EMployee
        //---Method to iterate through all employee and print(Dependt on print employee)
        //--Method to Get employee ID
        //---MEthdo to search EMployee
        //---Methdos to take id and search EMployee and printd(dependent on GetEmployeeID, SearchEmployee and PrintEmployee)
        //---Method to Update Name(Dependent on GetEmnployeeId, SearchEmployee, PrintEmployee)
        //---Methdo to delete employee(Note - Make the array reff as null)(Dependent on GetEmnployeeId, SearchEmployee, PrintEmployee)

        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        /// <summary>
        /// prints the menu for the applicatoin
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Edit Name of The employee");
            Console.WriteLine("5. Delete an employee");
            Console.WriteLine("0. Exit");
        }
        /// <summary>
        /// menu functionality
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        EditEmployeeName();
                        break;
                    case 5:
                        DeleteEmployee();
                        break; 
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        /// <summary>
        /// add an employee to the employees array
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        /// <summary>
        /// prints all employees in the array
        /// </summary>
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        /// <summary>
        /// creates new employee
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>returns employee</returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }
        /// <summary>
        /// prints one employee
        /// </summary>
        /// <param name="employee">returns employee</param>
        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        /// <summary>
        /// get user id from console
        /// </summary>
        /// <returns>return id</returns>
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        /// <summary>
        /// search thhe employee byid and prints it  
        /// </summary>
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        /// <summary>
        /// search employee by id 
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>employee id</returns>
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
          
        
        int GetEmployeeIdxFromId(int id)
        {
            for(int i = 0; i<employees.Length; i++)
            {
                if (employees[i]!=null && employees[i].Id == id)
                {
                    return i; 
                }
            }
            return -1; 
        }
       
        /// <summary>
        /// edit's employee name
        /// </summary>
        void EditEmployeeName()
        {
            Console.WriteLine("Enter UserId");
            int id;
            id = GetIdFromConsole(); 
            Employee emp = SearchEmployeeById(id); 
            Console.WriteLine("Enter the new name");
            string newName = Console.ReadLine();
            if (emp == null)
            {
                Console.WriteLine($"Employee with {id} does not exist");
                return; 
            }
            else
            {
                emp.Name = newName;
                Console.WriteLine("Employee Updated!");
                emp.PrintEmployeeDetails(); 
            }
        }
        
        /// <summary>
        /// deletes the employee
        /// </summary>
        void DeleteEmployee()
        {
            Console.WriteLine("Enter UserId");
            int id = GetIdFromConsole(); 
            int idx = GetEmployeeIdxFromId(id);
            if(idx == -1) { Console.WriteLine($"no employee exist with id:{id}"); }  
            employees[idx] = null;
            PrintAllEmployees(); 
            return; 
        }
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
