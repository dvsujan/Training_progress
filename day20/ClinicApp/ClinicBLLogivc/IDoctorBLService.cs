using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary; 

namespace ClinicBLLogivc
{
    internal interface IDoctorBLService
    {
        Doctor Delete(int key);
        Doctor Get(int key);
        Doctor Insert(Doctor item);
        Doctor Update(Doctor item);

        List<Appointment> GetAppointments(Doctor item);
    }
}
