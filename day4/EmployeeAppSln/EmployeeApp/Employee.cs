using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal class Employee
    {
        double salary;

        public string Name { get; set; }
        
        public double Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return (salary - (salary * 10 / 100));
            }
        }

        /// <summary>
        /// default constructor 
        /// </summary>
        public Employee()
        {
            this.salary = 0;
            this.Name = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Email = string.Empty;
        }

        /// <summary>
        ///  Constructor for the class Employee  
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="salary">Employee Salary</param>
        /// <param name="dateOfBirth">Employee DOB</param>
        /// <param name="email">Employee email</param>
        public Employee(string name, double salary, DateTime dateOfBirth, string email)
        {
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// work function 
        /// </summary>
        public void Work()
        {
            Console.WriteLine("Works");
        }
    }
}
