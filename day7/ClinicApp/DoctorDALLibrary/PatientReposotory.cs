using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public class PatientReposotory: IRepo<int, Patient>
    {
        readonly Dictionary<int, Patient> patients;
        public Patient Delete(int key)
        {
            Patient pat = patients[key];
            patients.Remove(key);
            return pat;
                 }

        public Patient Get(int key)
        {
            return patients[key];
        }

        public Patient Insert(Patient item)
        {
            patients.Add(item.Id, item);
            return item;
        }

        public Patient Update(Patient item)
        {
            patients[item.Id] = item;
            return item;
        }
    }
}
