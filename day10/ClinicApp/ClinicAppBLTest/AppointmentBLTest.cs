using ClinicBLLogivc;
using ClinicBLLogivc.Exceptions;
using ClinicDALLibrary;
using ClinicModelLibrary; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppBLTest 
{
    public class AppointmentBLTest
    {
        IAppointmentBLService _appointmentBLService;
        IRepo<int, Appointment> _appointmentRepo;
        Doctor d;
        Patient p; 

        [SetUp]
        public void Setup()
        {
            _appointmentRepo = new AppointmentReposotory();
            _appointmentBLService = new AppontmentBL(_appointmentRepo);
             d = new Doctor()
            {
                Id = 1,
                Name = "Doctor 1",
                Specialization = "D"
            };
            p = new Patient()
            {
                Id = 1,
                Name = "patient1",
            };
            Appointment appointment = new Appointment()
            {
                Id = 1,
                Date = DateTime.Now,
                Doctor = d,
                Patient = p
            };
            _appointmentBLService.Insert(appointment);
            Appointment appointment2 = new Appointment()
            {
                Id = 2,
                Date = DateTime.Now,
                Doctor = d,
                Patient = p
            };
            _appointmentBLService.Insert(appointment2);
        }

        [Test]
        public void TestDelete()
        {
            Appointment appointment = new Appointment()
            {
                Id = 5,
                Date = DateTime.Now,
                Doctor =d,
                Patient = p
            };
            var gg = _appointmentBLService.Insert(appointment);
            var a = _appointmentBLService.Delete(gg.Id);
            Assert.IsNotNull(a); 
        }
        [Test]
        public void TestGet()
        {
            Appointment appointment = new Appointment()
            {
                Id = 5,
                Date = DateTime.Now,
                Doctor = d ,
                Patient= p
            };
            _appointmentBLService.Insert(appointment);
            var a = _appointmentBLService.Get(appointment.Id);
            Assert.AreEqual(appointment, a);
        }
        [Test]
        public void TestInsert()
        {
            Appointment appointment = new Appointment()
            {
                Id = 5,
                Date = DateTime.Now,
                Doctor = d,
                Patient = p 
            };
            var a = _appointmentBLService.Insert(appointment);
            Assert.AreEqual(appointment, a);
        }
        [Test]
        public void TestUpdate()
        {

            Appointment appointment = new Appointment()
            {
                Id = 5,
                Date = DateTime.Now,
                Doctor = d,
                Patient = p
            };
            _appointmentBLService.Insert(appointment);
            appointment.Date = DateTime.Now.AddDays(1);
            var a = _appointmentBLService.Update(appointment);
            Assert.IsNotNull(a);
        }
        [Test]
        public void TestGetAppointmentsByDoctor()
        {
            var a = _appointmentBLService.GetAppointmentsByDoctor(d.Id);
            Assert.IsNotNull(a);
        }
        [Test]
        public void TestGetAppointmentsByPatient()
        {
            var a = _appointmentBLService.GetAppointmentsByPatient(p.Id);
            Assert.IsNotNull(a);
        }

        [Test]
        public void TestDeleteFail()
        {
            var a = _appointmentBLService.Delete(23);
            Assert.IsNull(a);
        }
        [Test]
        public void TestGetFail()
        {
            var a = _appointmentBLService.Get(23);
            Assert.IsNull(a);
        }
        [Test]
        public void TestUpdateFail()
        {
            Appointment appointment = new Appointment()
            {
                Id = 5,
                Date = DateTime.Now,
                Doctor = d,
                Patient = p
            };
            var a = _appointmentBLService.Update(appointment);
            Assert.IsNull(a);
        }
        [Test]
        public void TestGetAppointmentsByDoctorFail()
        {
            var a = _appointmentBLService.GetAppointmentsByDoctor(23);
            Assert.IsNotNull(a);
        }
        [Test]
        public void TestGetAppointmentsByPatientFail()
        {
            var a = _appointmentBLService.GetAppointmentsByPatient(23);
            Assert.IsNotNull(a);
        }

        [Test]
        public void TestInsertException()
        {
            Appointment appointment = new Appointment()
            {
                Id = 1,
                Date = DateTime.Now,
                Doctor = d,
                Patient = p
            };
            _appointmentBLService.Insert(appointment);

            Assert.Throws<AppointmentAlreadyExistsException>(() => _appointmentBLService.Insert(appointment));
        }
        [Test]
        public void TestDeleteException()
        {
            Assert.Throws<AppointmentNotFoundException>(() => _appointmentBLService.Delete(2424));
        }
        [Test]
        public void TestGetException()
        {
            Assert.Throws<AppointmentNotFoundException>(() => _appointmentBLService.Get(2424));
        }
        [Test]
        public void TestUpdateException()
        {
            Assert.Throws<AppointmentNotFoundException>(() => _appointmentBLService.Update(new Appointment()));
        }
        [Test]
        public void TestGetAppointmentsByDoctorException()
        {
            Assert.Throws<AppointmentNotFoundException>(() => _appointmentBLService.GetAppointmentsByDoctor(24));
        }
    }
}
