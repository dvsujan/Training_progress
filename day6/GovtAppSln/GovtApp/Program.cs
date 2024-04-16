using System.Runtime.InteropServices;

namespace GovtApp
{
    internal class Program
    {
        static double GetDoubleInput() {
            double input; 
            while(!double.TryParse(Console.ReadLine(), out input )) {
                Console.WriteLine("invalid input");
            }
            return input; 
        }
        static int GetIntInput() {
            int input; 
            while(!int.TryParse(Console.ReadLine(), out input )) {
                Console.WriteLine("invalid input");
            }
            return input; 
        }
        static float GetFloatInput() {
            float input; 
            while(!float.TryParse(Console.ReadLine(), out input )) {
                Console.WriteLine("invalid input");
            }
            return input; 
        }
        static void Main(string[] args)
        {
            int empid;
            string name;
            string desg;
            double basicSalary;
            float serviceYears; 
            Console.WriteLine("Enter employee Id");
            empid = GetIntInput();
            Console.WriteLine("Enter username");
            name = Console.ReadLine() ?? ""; 
            Console.WriteLine("Enter user designation");
            desg = Console.ReadLine() ?? ""; 
            Console.WriteLine("Enter basic Salary");
            basicSalary = GetDoubleInput();
            Console.WriteLine("Enter no of years in service");
            serviceYears = GetFloatInput();
            Console.WriteLine("Enter Company Name");
            string companyName = Console.ReadLine()??"";
            
            Emloyee employee = null;
            IGovtRules gvrt; 

            if (companyName == "CTS")
            {
                employee = new CTS(empid , name , desg, basicSalary);
                Console.WriteLine(employee);
                gvrt = employee; 
                Console.WriteLine($"Employee GratuityAmount: {gvrt.GratuityAmount(serviceYears, employee.BasicSalary)}");
            }
            else if (companyName == "Accenture")
            {
                employee = new Accenture(empid , name , desg, basicSalary) ;
                gvrt = employee; 
                Console.WriteLine(employee);
                Console.WriteLine($"Employee GratuityAmount : {gvrt.GratuityAmount(serviceYears,employee.BasicSalary)}");
            }
            else
            {
                Console.WriteLine("Invaid company name");
                return; 
            }
        }
    }
}
