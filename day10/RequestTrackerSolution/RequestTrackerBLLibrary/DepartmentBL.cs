using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
        }
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            for (int i = 0; i < _departmentRepository.GetAll().Count; i++)
            {
                if (_departmentRepository.GetAll()[i].Name == departmentOldName)
                {
                    _departmentRepository.GetAll()[i].Name = departmentNewName;
                    return _departmentRepository.GetAll()[i];
                }
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentById(int id)
        {
            if (_departmentRepository.Get(id) != null)
            {
                return _departmentRepository.Get(id);
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            for (int i = 0; i < _departmentRepository.GetAll().Count; i++)
            {
                if (_departmentRepository.GetAll()[i].Name == departmentName)
                {
                    return _departmentRepository.GetAll()[i];
                }
            }
            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            if (_departmentRepository.Get(departmentId) != null)
            {
                return _departmentRepository.Get(departmentId).Department_Head;
            }
            throw new DepartmentNotFoundException();
        }

        public List<Department> GetDepartmentList()
        {
            return _departmentRepository.GetAll();
        }
    }
}
