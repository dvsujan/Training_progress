using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;
namespace RequestTrackerTest
{
    public class DepartmentTest 
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository(); 
        }

        [Test]
        public void DepartmentAdd()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            
            var result = repository.Add(department); 
            Assert.AreEqual(1, result.Id);
            
        }
        [Test]
        public void DepartmentDelete()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            var result = repository.Delete(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void DepartmentGet()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            var result = repository.Get(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void DepartmentGetAll()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            Department departmentt = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(departmentt);  
            var result = repository.GetAll();
            Assert.IsNotNull(result);
        }
        [Test]
        public void DepartmentUpdate()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department.Name = "HR";
            var result = repository.Update(department);
            Assert.IsNotNull(result);
        }
        
        [TestCase(1, "Hr", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);
            Department departmentt = new Department() { Name = name, Department_Head = hid };
            repository.Add(departmentt);
            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}