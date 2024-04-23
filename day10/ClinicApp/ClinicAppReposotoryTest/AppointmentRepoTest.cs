using ClinicDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicAppReposotoryTest
{
    public class AppointmentRepoTest
    {
        IRepo<int, Appointment> _repo;
        Patient p;
        Doctor d; 
        
        [SetUp]
        public void SetUp()
        {
            _repo = new AppointmentReposotory();
            p = new Patient { Id = 1, Name = "John" };
            d = new Doctor { Id = 1, Name = "Dr. John" };
        }
        [Test]
        public void TestInsert()
        {
            Appointment appointment = new Appointment { Id = 1, Date = DateTime.Now, Patient=p, Doctor=d };
            var a = _repo.Insert(appointment);
            Assert.AreEqual(appointment, a);
        }
        [Test]
        public void TestUpdate()
        {
            Appointment appointment = new Appointment { Id = 1, Date = DateTime.Now, Patient=p, Doctor=d };
            _repo.Insert(appointment);
            appointment.Date = DateTime.Now.AddDays(1);
            var a = _repo.Update(appointment);
            Assert.AreEqual(appointment, a);
        }
        [Test]
        public void TestDelete()
        {
            Appointment appointment = new Appointment { Id = 1, Date = DateTime.Now, Patient=p, Doctor=d };
            _repo.Insert(appointment);
            var a = _repo.Delete(appointment.Id);
            Assert.AreEqual(appointment, a);
        }
        [Test]
        public void TestGet()
        {
            Appointment appointment = new Appointment { Id = 1, Date = DateTime.Now, Patient=p, Doctor=d };
            _repo.Insert(appointment);
            var a = _repo.Get(appointment.Id);
            Assert.AreEqual(appointment, a);
        }
        [Test]
        public void TestGetAll()
        {
            Appointment appointment = new Appointment { Id = 1, Date = DateTime.Now, Patient=p, Doctor=d };
            _repo.Insert(appointment);
            var a = _repo.GetAll();
            Assert.AreEqual(1, a.Count);
        }
        [Test]
        public void getAppointmentByDoctor()
        {
        }

    }
}
