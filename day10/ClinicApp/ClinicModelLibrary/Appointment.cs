using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Appointment()
        {
            Id = 0;
            Date = DateTime.Now;
            Time = "";
            Doctor = null;
            Patient = null;
        }
        [ExcludeFromCodeCoverage]
        public Appointment(DateTime date, string time, Doctor doctor, Patient patient)
        {
            Id = RandomId.GenerateInt();
            Date = date;
            Time = time;
            Doctor = doctor;
            Patient = patient;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}, Time: {Time}, Doctor: {Doctor}, Patient: {Patient}";
        }
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return obj is Appointment appointment && Id == appointment.Id;
        }
    }
}
