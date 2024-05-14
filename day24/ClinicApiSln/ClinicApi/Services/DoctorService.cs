using ClinicApi.Interfaces;
using ClinicApi.Models;

namespace ClinicApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepo<int, Doctor> _doctorRepo;
        public DoctorService(IRepo<int, Doctor> doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }
        public async Task<IEnumerable<Doctor>> FilterDoctorBasedOnSpeciality(string speciality)
        {
            try
            {
                IEnumerable<Doctor> docs = await _doctorRepo.GetAll();
                return docs.Where(d => d.Speciality == speciality);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            try
            {
                return await _doctorRepo.GetAll();
                 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int experience)
        {
            try
            {
                Doctor doc = await _doctorRepo.GetById(id);
                doc.Experience = experience;
                return await _doctorRepo.Update(doc);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
