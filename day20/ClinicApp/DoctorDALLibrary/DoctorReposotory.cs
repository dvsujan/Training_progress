using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicDALLibrary.Model;

namespace ClinicDALLibrary 
{
    public class DoctorReposotory : IRepo<int, Doctor>
    {
        private readonly ClinicAppContext _context;
        public Doctor Delete(int key)
        {
            Doctor doctor = _context.Doctors.Find(key);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Get(int key)
        {
            return _context.Doctors.Find(key);
        }

        public Doctor Insert(Doctor item)
        {
            _context.Doctors.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Doctor Update(Doctor item)
        {
            _context.Doctors.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
