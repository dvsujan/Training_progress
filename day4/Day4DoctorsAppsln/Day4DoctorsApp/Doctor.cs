using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4DoctorsApp
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }
        public Doctor()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Age = 0;
            this.Qualification = string.Empty;
            this.Speciality = string.Empty;
        }
        /// <summary>
        /// Constructor for doctor class 
        /// </summary>
        /// <param name="id">Doctor Id </param>
        /// <param name="name">Doctor Name</param>
        /// <param name="age">Doctor age</param>
        /// <param name="qualification">Doctor qualification</param>
        /// <param name="speciality">Doctor speciality</param>
        public Doctor(int id, string name, int age, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Qualification = qualification;
            Speciality = speciality;
        }
        /// <summary>
        /// Prints the doctor details
        /// </summary>
        public void printDoctorData()
        {
            Console.WriteLine($"Doctor Id: {this.Id}");
            Console.WriteLine($"Doctor Name: {this.Name}");
            Console.WriteLine($"Doctor Age: {this.Age}");
            Console.WriteLine($"Doctor Qualification: {this.Qualification}");
            Console.WriteLine($"Doctor Speciality: {this.Speciality}");
        }
    }
}
