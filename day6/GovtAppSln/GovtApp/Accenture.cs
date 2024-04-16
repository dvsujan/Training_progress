using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GovtApp
{
    internal class Accenture : Emloyee,IGovtRules
    {
        public Accenture():base(){ 
         }
        public Accenture(int empid, string name, string desg, double basicSalary) : base(empid, name, desg, basicSalary)
        {
        }
        
        public double EmployeePF(double basicSalary)
        {
            return Math.Round(basicSalary * 0.12, 2);  
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0; 
        }

        public string LeaveDetails()
        {
            return "2 day of Casual Leave per month\n 5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }
        public override string ToString()
        {
            return base.ToString()+$"\nemployee PF: {EmployeePF(this.BasicSalary)}\nLeave Info:\n {LeaveDetails()}";
        }
    }
}
