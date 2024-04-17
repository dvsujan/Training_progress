using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public  class AppointmentReposotory:IRepo<int, Appointment>
    {
        readonly Dictionary<int, Appointment> appointments;
        public Appointment Delete(int key)
        {
            Appointment app = appointments[key];
            appointments.Remove(key);
            return app;
        }

        public Appointment Get(int key)
        {
            return appointments[key];
        }

        public Appointment Insert(Appointment item)
        {
            appointments.Add(item.Id, item);
            return item;
        }

        public Appointment Update(Appointment item)
        {

            appointments[item.Id] = item;
            return item;    
        }
    }
}
