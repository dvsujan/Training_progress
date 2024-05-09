using System;
using System.Collections.Generic;
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
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Appointment()
        {
            Id = 0;
            Date = DateTime.Now;
            Time = "";
        }
        public override bool Equals(object obj)
        {
            return obj is Appointment appointment && Id == appointment.Id;
        }
        public static bool operator ==(Appointment appointment1, Appointment appointment2)
        {
            return appointment1.Equals(appointment2);
        }
        public static bool operator !=(Appointment appointment1, Appointment appointment2)
        {
            return !appointment1.Equals(appointment2);
        }   
    }
}
