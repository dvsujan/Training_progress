using ClinicApi.contexts;
using ClinicApi.Interfaces;
using ClinicApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicApi.Repositories
{
    public class DoctorRepository:IRepo<int , Doctor>
    {
        private readonly ClinicAppContext _context;
        public DoctorRepository(ClinicAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await  _context.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetById(int id)
        {
            Doctor? doc = await _context.Doctors.SingleOrDefaultAsync(d => d.Id == id) ?? throw new Exception("Doctor not found");
            return doc;
        }
        public async Task<Doctor> Add(Doctor entity)
        {
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Doctor> Update(Doctor entity)
        {
            Doctor? doctor = await GetById(entity.Id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Doctor> Delete(int id)
        {
            Doctor? doctor = await GetById(id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
    }
}
