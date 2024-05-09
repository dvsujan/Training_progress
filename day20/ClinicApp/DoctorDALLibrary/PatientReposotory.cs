using ClinicDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary
{
    public class PatientReposotory: IRepo<int, Patient>
    {
        private readonly ClinicAppContext _context;
        public Patient Delete(int key)
        {
            Patient patient = _context.Patients.Find(key);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient Get(int key)
        {
            return _context.Patients.Find(key);
        }

        public Patient Insert(Patient item)
        {
            _context.Patients.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Patient Update(Patient item)
        {
            _context.Patients.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
