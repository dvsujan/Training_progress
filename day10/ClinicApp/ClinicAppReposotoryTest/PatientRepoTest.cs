using ClinicDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;


namespace ClinicAppReposotoryTest
{
    public class PatientRepoTest
    {
        IRepo<int, Patient> repo; 
        [SetUp]
        public void Setup()
        {
            repo = new PatientReposotory();
        }
        [Test]
        public void TestInsert()
        {
            Patient patient = new Patient { Id = 1, Name = "John" }; 
            var p = repo.Insert(patient);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void TestUpdate()
        {
            Patient patient = new Patient { Id = 1, Name = "John" };
            repo.Insert(patient);
            patient.Name = "John Doe";
            var p = repo.Update(patient);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void TestDelete()
        {
            Patient patient = new Patient { Id = 1, Name = "John" };
            repo.Insert(patient);
            var p = repo.Delete(patient.Id);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void TestGet()
        {
            Patient patient = new Patient { Id = 1, Name = "John" };
            repo.Insert(patient);
            var p = repo.Get(patient.Id);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void TestGetAll()
        {
            Patient patient = new Patient { Id = 1, Name = "John" };
            repo.Insert(patient);
            var p = repo.GetAll();
            Assert.AreEqual(1, p.Count);
        }
    }
}
