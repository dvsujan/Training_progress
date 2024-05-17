using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
        public Task<EnableUserReturnDTO> EnableUser(EnableUserDTO e);
        public Task<Request> RaiseRequest(RequestDTO requestDTO);
        public Task<IEnumerable<Request>> GetRequests(int userId);
    }
}
