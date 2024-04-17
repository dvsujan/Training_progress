using ClinicDALLibrary;
using ClinicModelLibrary;
namespace ClinicBLLogivc
{
    public class DoctorBL:IDoctorBLService
    {
        readonly IRepo<int, Doctor> _doctorReposotory; 
        public DoctorBL()
        {
            _doctorReposotory= new DoctorReposotory();
        }

        public Doctor Delete(int key)
        {
            return null; 
        }

        public Doctor Get(int key)
        {
            return null; 
        }

        public Doctor Insert(Doctor item)
        {
            return null; 
        }

        public Doctor Update(Doctor item)
        {
            return null; 
        }
        
        public List<Appointment> GetAppointments(Doctor item)
        {
            return null;  
        }

    }
}
