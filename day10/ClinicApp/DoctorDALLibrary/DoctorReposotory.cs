using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary; 

namespace ClinicDALLibrary 
{
    public class DoctorReposotory : IRepo<int, Doctor>
    {
        readonly Dictionary<int, Doctor>? doctors;

        [ExcludeFromCodeCoverage]
        public DoctorReposotory()
        {
            doctors = new Dictionary<int, Doctor>();
        }

        public Doctor Delete(int key)
        {
            Doctor doc = doctors[key];
           doctors.Remove(key);
            return doc; 
        }

        public Doctor Get(int key)
        {
            return doctors[key];
        }
        
        public List<Doctor> GetAll()
        {
            
            return doctors.Values.ToList();
        }
        public Doctor Insert(Doctor item)
        {
            if (doctors.ContainsKey(item.Id) == true)
            {
                return null; 
            }
            doctors.Add(item.Id, item);
            return doctors[item.Id];
        }
        public Doctor Update(Doctor item)
        {
            if (doctors.ContainsKey(item.Id) == false)
            {
                return null; 
            }
            doctors[item.Id] = item;
            return item;
        }
    }
}
