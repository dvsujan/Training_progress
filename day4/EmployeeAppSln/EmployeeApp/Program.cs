using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static Employee getEmployeeData(int id)
        {
            Employee employee = new Employee();
            string name,email;
            double salary;
            DateTime DOB;
            Console.WriteLine("enter name of employee");
            email = Console.ReadLine(); 
            Console.WriteLine("enter salary of employee");
            if(!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Not a valid salary");
            }
            Console.WriteLine("enter DOB of employee");
            Console.WriteLine("enter Email of employee");
            return employee; 

            
        }
        static void Main(string[] args)
        {
            //Employee employee = new Employee();
            //employee.Name = "abc";
            //employee.Salary = 10000;
            //employee.DateOfBirth = new DateTime(2000, 12, 18);
            //employee.Email = "a@a.com";
            //Employee employee2 = new Employee{
            //    Name = "Somu",
            //    DateOfBirth = new DateTime(2000, 3, 6),
            //    Email = "somu@abccorp.com",
            //    Salary = 40000
            //};
            
            //Console.WriteLine(employee2.Salary);
            //employee.Work();
            
            int n;
            Console.WriteLine("Enter No of employees");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("not a valid number");
                return; 
            }
            Employee[] employeeList = new Employee[n];




        }
    }
}

