using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime dob { get; set; }
        public string specalization { get; set; }
        public double age { get => (DateTime.Now - dob).TotalDays / 365.25; }
        public string Specialization { get; set; }
        public Doctor()
        {
            this.Id = 0;
            this.Name = "";
            this.dob = DateTime.Now;
            this.Specialization = "";
            this.specalization = null; 
        }
        public Doctor(string name, DateTime dob,string department ,  string specialization)
        {
            Id = RandomId.GenerateInt();
            Name = name;
            this.dob = dob;
            this.specalization = department;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {age}, Specialization: {Specialization}";
        }
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return obj is Doctor doctor && Id == doctor.Id; 
        }
    }
}
