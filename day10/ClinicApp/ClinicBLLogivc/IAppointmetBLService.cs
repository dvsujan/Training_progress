using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;


namespace ClinicBLLogivc
{
    public interface IAppointmentBLService
    {
        List<Appointment> GetAppointmentsByDoctor(int doctorId);
        List<Appointment> GetAppointmentsByPatient(int patientId);
        Appointment Delete(int key);
        Appointment Get(int key);
        Appointment Insert(Appointment item);
        Appointment Update(Appointment item);
    }
}
