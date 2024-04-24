using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBLLogivc;

using ClinicModelLibrary;
using ClinicDALLibrary;
using System.Diagnostics.CodeAnalysis;

namespace ClinicBLLogivc
{
    public class PatientBL: IPatientBLServie
    {
        readonly IRepo<int, Patient> _patientRepo;
        readonly IRepo <int , Appointment> _appointmentRepo;
        [ExcludeFromCodeCoverage]
        public PatientBL()
        {
        }
        [ExcludeFromCodeCoverage]
        public PatientBL(IRepo<int, Patient> patientRepo, IRepo<int , Appointment> appointmentRepo)
        {
            _patientRepo = patientRepo;
            _appointmentRepo = appointmentRepo; 
        }

        public Patient Delete(int key)
        {
            for (int i = 0; i < _patientRepo.GetAll().Count; i++)
            {
                if (_patientRepo.GetAll()[i].Id == key)
                {
                    var p = _patientRepo.Delete(key);
                    return p;
                }
            }
            throw new PatientNotFoundException(); 
        }

        public Patient Get(int key)
        {
            for (int i = 0; i < _patientRepo.GetAll().Count; i++)
            {
                if (_patientRepo.GetAll()[i].Id == key)
                {
                    return _patientRepo.Get(key);
                }
            }
            throw new PatientNotFoundException();
        }

        public Patient Insert(Patient item)
        {
            for (int i = 0; i < _patientRepo.GetAll().Count; i++)
            {
                if (_patientRepo.GetAll()[i].Id == item.Id)
                {
                    throw new PatientAlreadyExistsException();
                }
            }
            return _patientRepo.Insert(item);
        }
        public Patient Update(Patient item)
        {
            for (int i = 0; i < _patientRepo.GetAll().Count; i++)
            {
                if (_patientRepo.GetAll()[i].Id == item.Id)
                {
                    return _patientRepo.Update(item);
                }
            }
            throw new PatientNotFoundException();
        }
        public List<Appointment> GetAppointments(Patient item)
        {
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < _appointmentRepo.GetAll().Count; i++)
            {
                if (_appointmentRepo.GetAll()[i].Patient.Id == item.Id)
                {
                    appointments.Add(_appointmentRepo.GetAll()[i]);
                }
            }
            return appointments;

        }
    }
}
