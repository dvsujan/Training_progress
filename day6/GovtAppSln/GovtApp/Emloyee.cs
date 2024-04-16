using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtApp
{
    internal class Emloyee:IGovtRules
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Desg { get; set; }
        public double BasicSalary { get; set; }


        public Emloyee()
        {
            EmpId = 0;
            Name = String.Empty; 
            Desg = String.Empty;
            BasicSalary = 0;
        }
        public Emloyee(int empid, string name, string desg, double basicSalary)
        {
            EmpId = empid;
            Name = name;
            Desg = desg;
            BasicSalary = basicSalary;
        }
        public override string ToString()
        {
            return $"--------------------\nEmployee Details:\n----------------\nEmployee Id: {this.EmpId}\nEmployee Name: {this.Name}\nEmployee Desg: {this.Desg}\nEmployee Basic Salary: {this.BasicSalary}"; 
        }

        public double EmployeePF(double basicSalary)
        {
            throw new NotImplementedException();
        }

        public string LeaveDetails()
        {
            throw new NotImplementedException();
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            throw new NotImplementedException();
        }
    }
}
