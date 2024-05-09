using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary; 

namespace ClinicBLLogivc
{
    public interface IPatientBLServie
    {
        Patient Delete(int key);
        Patient Get(int key);
        Patient Insert(Patient item);
        Patient Update(Patient item);
        public List<Appointment> GetAppointments(Patient item); 
    }
}
