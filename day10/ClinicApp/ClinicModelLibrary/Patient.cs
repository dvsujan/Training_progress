using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime dob { get; set; }
        public double age { get => (DateTime.Now - dob).TotalDays / 365.25; }
        public Patient()
        {
            this.Id = 0;
            this.Name = "";
            this.dob = DateTime.Now;
        }
        [ExcludeFromCodeCoverage]
        public Patient(string name, DateTime dob)
        {
            Id = RandomId.GenerateInt();
            Name = name;
            this.dob = dob;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {age}";
        }

        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return obj is Patient patient && Id == patient.Id;
        }
    }
}
