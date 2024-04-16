using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtApp
{
    internal class CTS:Emloyee,IGovtRules
    {
        public CTS():base() {
        }
        public CTS(int empid, string name, string desg, double basicSalary) : base(empid, name, desg, basicSalary)
        {
        }

        public double EmployeePF(double basicSalary)
        {
            return Math.Round(basicSalary * 0.0367, 2);  
        }

        public string LeaveDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year\r\n "; 
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
                return 3 * basicSalary;
            else if (serviceCompleted > 10)
                return 2 * basicSalary;
            else if (serviceCompleted > 5)
            {
                return basicSalary * 0.083;// 1/12 = 0.083 
            }
            else if (serviceCompleted < 5)
                return basicSalary;
            else
                return -1; 
        }
        public override string ToString()
        {
            return base.ToString() + $"\nemployee PF: {EmployeePF(this.BasicSalary)}\nLeave Info:\n {LeaveDetails()}";
        }
    }
}
