using ClinicDALLibrary;
using ClinicModelLibrary;
using ClinicBLLogivc.Exceptions;
using System.Diagnostics.CodeAnalysis;
namespace ClinicBLLogivc
{
    public class DoctorBL:IDoctorBLService
    {
        readonly IRepo<int, Doctor> _doctorReposotory;
        readonly IRepo<int, Appointment> _appointmentReposotory;
        [ExcludeFromCodeCoverage]
        public DoctorBL(IRepo<int, Doctor> doctorrepo, IRepo<int, Appointment> appointmentRepo )
        {
            _doctorReposotory = doctorrepo;
            _appointmentReposotory = appointmentRepo;
        }

        public Doctor Delete(int key)
        {
            for (int i = 0; i < _doctorReposotory.GetAll().Count; i++)
            {
                if (_doctorReposotory.GetAll()[i].Id == key)
                {
                    var d = _doctorReposotory.Delete(key);
                    return d;
                }
            }
            throw new DoctorNotFoundException();
             
        }

        public Doctor Get(int key)
        {
            for (int i = 0; i < _doctorReposotory.GetAll().Count; i++)
            {
                if (_doctorReposotory.GetAll()[i].Id == key)
                {
                    return _doctorReposotory.Get(key);
                }
            }
            throw new DoctorNotFoundException(); 
        }

        public Doctor Insert(Doctor item)
        {
            for (int i = 0; i < _doctorReposotory.GetAll().Count; i++)
            {
                if (_doctorReposotory.GetAll()[i].Id == item.Id)
                {
                    throw new DoctorAlreadyExistsException();
                }
            }
            return _doctorReposotory.Insert(item);
        }

        public Doctor Update(Doctor item)
        {
            for (int i = 0; i < _doctorReposotory.GetAll().Count; i++)
            {
                if (_doctorReposotory.GetAll()[i].Id == item.Id)
                {
                    return _doctorReposotory.Update(item);
                }
            }
            throw new DoctorNotFoundException();
        }
        
        public List<Appointment> GetAppointments(Doctor item)
        {
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < _appointmentReposotory.GetAll().Count; i++)
            {
                if (_appointmentReposotory.GetAll()[i].Doctor.Id == item.Id)
                {
                    appointments.Add(_appointmentReposotory.GetAll()[i]);
                }
            }
            if(appointments.Count == 0)
            {
                throw new AppointmentNotFoundException();
            }
            return appointments;

        }
    }
}
