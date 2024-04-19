using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }
        
        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee) ; 
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeNameException();
        }

        public Employee ChangeEmployeeDepartment(int employeeId, int departmentId)
        {
            for (int i = 0; i < _employeeRepository.GetAll().Count; i++)
            {
                if (_employeeRepository.GetAll()[i].Id == employeeId)
                {
                    _employeeRepository.GetAll()[i].EmployeeDepartment.Id = departmentId;
                    return _employeeRepository.GetAll()[i];
                }
            }
            throw new EmployeeNotFoundException();
        }

        public Employee ChangeEmployeeName(string employeeOldName, string employeeNewName)
        {
            for(int i = 0; i < _employeeRepository.GetAll().Count; i++)
            {
                if (_employeeRepository.GetAll()[i].Name == employeeOldName)
                {
                    _employeeRepository.GetAll()[i].Name = employeeNewName;
                    return _employeeRepository.GetAll()[i];
                }
            }
            throw new EmployeeNotFoundException();
        }
        
        public Employee GetEmployeeById(int id)
        {
            if (_employeeRepository.Get(id) == null)
            {
                throw new EmployeeNotFoundException();
            }
                return _employeeRepository.Get(id);
        }
        
        public Employee GetEmployeeByName(string employeeName)
        {
            for (int i = 0; i < _employeeRepository.GetAll().Count; i++)
            {
                if (_employeeRepository.GetAll()[i].Name == employeeName)
                {
                    return _employeeRepository.GetAll()[i];
                }
            }
            throw new EmployeeNotFoundException();
        }
    }
}
