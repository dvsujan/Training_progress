using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;
using ClinicDALLibrary;
using ClinicBLLogivc.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ClinicBLLogivc
{
    public class AppontmentBL: IAppointmentBLService
    {
        readonly private IRepo<int, Appointment> _appointmentRepo;

        [ExcludeFromCodeCoverage]
        public AppontmentBL()
        {
        }
        [ExcludeFromCodeCoverage]
        public AppontmentBL(IRepo<int, Appointment> appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public Appointment Delete(int key)
        {
            for (int i = 0; i < _appointmentRepo.GetAll().Count; i++)
            {
                if (_appointmentRepo.GetAll()[i].Id == key)
                {
                    return _appointmentRepo.Delete(key);
                }
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment Get(int key)
        {
            for (int i = 0; i < _appointmentRepo.GetAll().Count; i++)
            {
                if (_appointmentRepo.GetAll()[i].Id == key)
                {
                    return _appointmentRepo.Get(key);
                }
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment Insert(Appointment item)
        {
            for (int i = 0; i < _appointmentRepo.GetAll().Count; i++)
            {
                if (_appointmentRepo.GetAll()[i].Id == item.Id)
                {
                    throw new AppointmentAlreadyExistsException();
                }
            }
            return _appointmentRepo.Insert(item);
        }

        public Appointment Update(Appointment item)
        {
            for (int i = 0; i < _appointmentRepo.GetAll().Count; i++)
            {
                if (_appointmentRepo.GetAll()[i].Id == item.Id)
                {
                    return _appointmentRepo.Update(item);
                }
            }
            throw new AppointmentNotFoundException();
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            List<Appointment> appointments = _appointmentRepo.GetAll();
            List<Appointment> doctorAppointments = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Doctor.Id == doctorId)
                {
                    doctorAppointments.Add(appointment);
                }
         
            }
            if (doctorAppointments.Count == 0)
            {
                throw new AppointmentNotFoundException();
            }
            return doctorAppointments;
        }

        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            List<Appointment> appointments = _appointmentRepo.GetAll();
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Patient.Id == patientId)
                {
                    patientAppointments.Add(appointment);
                }
            }
            if (patientAppointments.Count == 0)
            {
                throw new AppointmentNotFoundException();
            }
            return appointments;
        }   
    }
}
