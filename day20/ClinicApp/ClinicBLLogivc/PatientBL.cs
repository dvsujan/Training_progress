using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBLLogivc;

using ClinicModelLibrary;
using ClinicDALLibrary;

namespace ClinicBLLogivc
{
    internal class PatientBL: IPatientBLServie
    {
        readonly IRepo<int, Patient> _patientRepo;
        public PatientBL()
        {
            _patientRepo = new PatientReposotory();
        }

        public Patient Delete(int key)
        {
            return null;  
        }

        public Patient Get(int key)
        {
            return null;  
        }

        public Patient Insert(Patient item)
        {
            return null; 
        }

        public Patient Update(Patient item)
        {
            return null;  
        }
        public List<Appointment> GetAppointments(Patient item){
            return null; 
        }
    }
}
