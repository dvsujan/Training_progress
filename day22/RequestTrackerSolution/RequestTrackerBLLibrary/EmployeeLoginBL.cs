using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL(RequestTrackerContext _context)
        {
            IRepository<int, Employee> repo = new EmployeeRequestRepository(_context);
            _repository = repo;
        }
        public async Task<Employee> Login(Employee employee)
        {
           var emp = await _repository.Get(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                    return emp; 
            }
            throw new Exception("Login Failed");
        }
        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            if(result != null)
                return result;
            throw new Exception("Registration Failed");
        }
    }
}
