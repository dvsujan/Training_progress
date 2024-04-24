using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBLLogivc;
using ClinicBLLogivc.Exceptions;
using ClinicDALLibrary;
using ClinicModelLibrary;

namespace ClinicAppBLTest
{
    public class DoctorBLTest
    {
        IDoctorBLService _doctorBLService; 
        IRepo<int , Appointment> _appointmentRepo;
        IRepo<int, Doctor> _doctorRepo;

        [SetUp]
        public void Setup()
        {
            _doctorRepo = new DoctorReposotory();
            _appointmentRepo = new AppointmentReposotory();
            _doctorBLService = new DoctorBL(_doctorRepo, _appointmentRepo);
            Appointment appointment = new Appointment()
            {
                Id = 1,
                Date = DateTime.Now,
                Doctor = new Doctor()
                {
                    Id = 1,
                    Name = "Doctor 1",
                    Specialization = "D"
                },
                Patient = new Patient()
                {
                    Id = 1,
                    Name = "patient1",
                }
            };
            _appointmentRepo.Insert(appointment);
            Appointment appointment2 = new Appointment()
            {
                Id = 2,
                Date = DateTime.Now,
                Doctor = new Doctor()
                {
                    Id = 1,
                    Name = "Doctor 1",
                    Specialization = "D"
                },
                Patient = new Patient()
                {
                    Id = 1,
                    Name = "patient1",
                }
            };
            _appointmentRepo.Insert(appointment2);
        }
        [Test]
        public void TestDelete()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Dr. John",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            var d = _doctorBLService.Delete(doctor.Id);
            Assert.AreEqual(doctor, d);
        }
        [Test]
        public void TestGet()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Dr. John",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            var d = _doctorBLService.Get(doctor.Id);
            Assert.AreEqual(doctor, d);
        }
        [Test]
        public void TestInsert()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Dr. John",
                Specialization = "D"
            };
            var d = _doctorBLService.Insert(doctor);
            Assert.AreEqual(doctor, d);
        }
        [Test]
        public void TestUpdate()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Dr. John",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            doctor.Name = "Dr. John Doe";
            var d = _doctorBLService.Update(doctor);
            Assert.AreEqual(doctor, d);
        }
        [Test]
        public void TestGetAppointments()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Doctor 1",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            var a = _doctorBLService.GetAppointments(doctor);
            Assert.AreEqual(2, a.Count);
        }
        [Test]
        public void TestDeleteFail()
        {
            Assert.IsNull(_doctorBLService.Delete(1));
        }
        [Test]
        public void TestGetFail()
        {
            Assert.IsNull(_doctorBLService.Get(1));
        }
        [Test]
        public void TestUpdateFail()
        {
            Assert.IsNull(_doctorBLService.Update(new Doctor()));
        }
        [Test]
        public void TestInsertFail()
        {
            Assert.IsNull(_doctorBLService.Insert(new Doctor()));
        }
        [Test]
        public void TestGetAppointmentsFail()
        {
            Assert.IsNull(_doctorBLService.GetAppointments(new Doctor()));
        }

        [Test]
        public void TestDeleteException()
        {
            Assert.Throws<DoctorNotFoundException>(() => _doctorBLService.Delete(1));
        }
        [Test]
        public void TestGetException()
        {
            Assert.Throws<DoctorNotFoundException>(() => _doctorBLService.Get(1));
        }
        [Test]
        public void TestUpdateException()
        {
            Assert.Throws<DoctorNotFoundException>(() => _doctorBLService.Update(new Doctor()));
        }
        [Test]
        public void TestInsertException()
        {
            _doctorBLService.Insert(new Doctor()
            {
                Id = 1,
                Name = "doc",
                Specialization = "D"
            });
            Assert.Throws<DoctorAlreadyExistsException>(() => _doctorBLService.Insert(new Doctor()
            {
                Id=1,
                Name="doc",
                Specialization="D",
            }));
        }
        [Test]
        public void TestGetAppointmentsException()
        {
            Assert.Throws<AppointmentNotFoundException>(() => _doctorBLService.GetAppointments(new Doctor()));
        }

        [Test]
        public void TestGetAppointmentsFail2()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Doctor 1",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            var a = _doctorBLService.GetAppointments(doctor);
            Assert.AreNotEqual(1, a.Count);
        }
        [Test]
        public void TestGetAppointmentsFail3()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Doctor 1",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            var a = _doctorBLService.GetAppointments(doctor);
            Assert.AreNotEqual(0, a.Count);
        }
        [Test]
        public void TestGetAppointmentsFail4()
        {
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Doctor 1",
                Specialization = "D"
            };
            _doctorBLService.Insert(doctor);
            var a = _doctorBLService.GetAppointments(doctor);
            Assert.AreNotEqual(3, a.Count);
        }
    }
}
