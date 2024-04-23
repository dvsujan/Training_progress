using ClinicBLLogivc;
using ClinicBLLogivc.Exceptions;
using ClinicDALLibrary;
using ClinicModelLibrary;
namespace ClinicAppBLTest
{
    public class patientBLTest 
    {

        IPatientBLServie _patientBLServie;
        IRepo <int , Appointment> _appointmentRepo;
        IRepo<int, Patient> _patientRepo;
        [SetUp]
        public void Setup()
        {
            _appointmentRepo = new AppointmentReposotory();
            _patientRepo = new PatientReposotory();
            _patientBLServie = new PatientBL(_patientRepo, _appointmentRepo);
        }

        [Test]
        public void PatientBLAdd()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            var p = _patientBLServie.Insert(patient);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void PatientBLUpdate()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            _patientBLServie.Insert(patient);
            patient.Name = "John Doe";
            var p = _patientBLServie.Update(patient);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void PatientBLDelete()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            _patientBLServie.Insert(patient);
            var p = _patientBLServie.Delete(patient.Id);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void PatientBLGet()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            _patientBLServie.Insert(patient);
            var p = _patientBLServie.Get(patient.Id);
            Assert.AreEqual(patient, p);
        }
        [Test]
        public void PatientBLGetAppointments()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            _patientBLServie.Insert(patient);
            var p = _patientBLServie.GetAppointments(patient);
            Assert.AreEqual(0, p.Count);
        }
        public void PatientBLAddFail()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            var p = _patientBLServie.Insert(patient);
            Assert.AreNotEqual(patient, p);
        }
        [Test]
        public void PatientBLUpdateFail()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            _patientBLServie.Insert(patient);
            patient.Name = "John Doe";
            var p = _patientBLServie.Update(patient);
            Assert.AreNotEqual(patient, p);
        }

        [Test]
        public void PatientBLDeleteFail()
        {
            var p = _patientBLServie.Delete(100);
            Assert.IsNotNull(p);
        }

        [Test]
        public void PatientBLGetFail()
        {
            var p = _patientBLServie.Get(100);
            Assert.IsNotNull(p);
        }

        [Test]
        public void PatientBLGetAppointmentsFail()
        {
            Patient patient = new Patient()
            {
                Id = 100,
            };
            var p = _patientBLServie.GetAppointments(patient);
            Assert.AreNotEqual(1, p.Count);
        }
        [Test]
        public void PatientBLAddException()
        {
            Patient patient = new Patient()
            {
                Id = 1,
                Name = "John",
            };
            var p = _patientBLServie.Insert(patient);
            Assert.Throws<PatientAlreadyExistsException>(() => _patientBLServie.Insert(patient));
        }
        [Test]
        public void PatientBLUpdateException()
        {
            Patient patient = new Patient()
            {
                Id = 12121,
                Name = "pat",
            };
            Assert.Throws<PatientNotFoundException>(() => _patientBLServie.Update(patient));
        }
        [Test]
        public void PatientBLDeleteException()
        {
            Assert.Throws<PatientNotFoundException>(() => _patientBLServie.Delete(1212));
        }
        [Test]
        public void PatientBLGetException()
        {
            Assert.Throws<PatientNotFoundException>(() => _patientBLServie.Get(1010));
        }
        [Test]
        public void PatientBLGetAppointmentsException()
        {
            Patient patient = new Patient()
            {
                Id = 11212,
                Name = "don",
            };
            Assert.Throws<PatientNotFoundException>(() => _patientBLServie.GetAppointments(patient));
        }
    }
}