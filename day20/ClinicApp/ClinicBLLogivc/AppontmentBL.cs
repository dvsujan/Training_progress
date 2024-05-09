using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;
using ClinicDALLibrary; 

namespace ClinicBLLogivc
{
    internal class AppontmentBL: IAppointmentBLService
    {
        readonly private IRepo<int, Appointment> _appointmentRepo;

        public AppontmentBL()
        {
            _appointmentRepo = new AppointmentReposotory();
        }

        public Appointment Delete(int key)
        {
            return null; 
        }

        public Appointment Get(int key)
        {
            return null; 
        }

        public Appointment Insert(Appointment item)
        {
            return null; 
        }

        public Appointment Update(Appointment item)
        {
            return null; 
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            return null; 
        }

        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            return null; 
        }   
    }
}
