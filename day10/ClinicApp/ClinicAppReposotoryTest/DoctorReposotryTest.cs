using ClinicDALLibrary;
using ClinicModelLibrary; 

namespace ClinicAppReposotoryTest
{
    public class DoctorReposotoryTest
    {
        IRepo<int, Doctor> repo;

        [SetUp]
        public void Setup()
        {

            repo = new DoctorReposotory();
        }

        [Test]
        public void DoctorAdd()
        {
            Doctor doc = new Doctor("doc1",DateTime.Now,"cardio","heart"); 
            var result = repo.Insert(doc);
            Assert.AreEqual(result.Id, doc.Id);
        }
        [Test]
        public void DoctorUpdate()
        {
            Doctor doc = new Doctor("doc1",DateTime.Now,"cardio","heart");
            repo.Insert(doc);
            doc.Specialization = "neuro";
            var result = repo.Update(doc);
            Assert.AreEqual(result.Specialization, "neuro");
        }
        [Test]
        public void DoctorDelete()
        {
            Doctor doc = new Doctor("doc1",DateTime.Now,"cardio","heart");
            repo.Insert(doc);
            var result = repo.Delete(doc.Id);
            Assert.AreEqual(result.Id, doc.Id);
        }
        [Test]
        public void DoctorGet()
        {
            Doctor doc = new Doctor("doc1",DateTime.Now,"cardio","heart");
            repo.Insert(doc);
            var result = repo.Get(doc.Id);
            Assert.AreEqual(result.Id, doc.Id);
        }
        [Test]
        public void DoctorGetAll()
        {
            Doctor doc = new Doctor("doc1",DateTime.Now,"cardio","heart");
            repo.Insert(doc);
            var result = repo.GetAll();
            Assert.AreEqual(result.Count, 1);
        }
    }
}