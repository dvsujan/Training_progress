using ClinicDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary
{
    public  class AppointmentReposotory:IRepo<int, Appointment>
    {
        private readonly ClinicAppContext _context;
        public Appointment Delete(int key)
        {
            Appointment appointment = _context.Appointments.Find(key);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment Get(int key)
        {
            return _context.Appointments.Find(key);
        }

        public Appointment Insert(Appointment item)
        {
            _context.Appointments.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Appointment Update(Appointment item)
        {
            _context.Appointments.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
