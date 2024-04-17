using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary; 

namespace ClinicDALLibrary 
{
    public class DoctorReposotory : IRepo<int, Doctor>
    {
        readonly Dictionary<int, Doctor>? doctors;
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

        public Doctor Insert(Doctor item)
        {
            doctors.Add(item.Id, item);
            return item;
        }

        public Doctor Update(Doctor item)
        {
            doctors[item.Id] = item;
            return item;
        }
    }
}
