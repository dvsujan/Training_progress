using ClinicApi.Models;

namespace ClinicApi.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> UpdateDoctorExperience(int id , int experience);
        Task<IEnumerable<Doctor>> FilterDoctorBasedOnSpeciality(string speciality);
    }
}
