using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Services;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UserService : IUserService
    {
        private readonly IReposiroty<int, User> _userRepo;
        private readonly IReposiroty<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;
        private readonly IReposiroty<int, Request> _requestRepo;

        public UserService(IReposiroty<int, User> userRepo, IReposiroty<int, Employee> employeeRepo, ITokenService tokenService, IReposiroty<int, Request> requestRepo)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
            _requestRepo = requestRepo;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.Get(loginDTO.UserId);
                if (userDB.Status == "Active")
                {
                    LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                    return loginReturnDTO;
                }
                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Employee> Register(EmployeeUserDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = employeeDTO;
                user = MapEmployeeUserDTOToUser(employeeDTO);
                employee = await _employeeRepo.Add(employee);
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);
                ((EmployeeUserDTO)employee).Password = string.Empty;

                return employee;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.Delete(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(EmployeeUserDTO employeeDTO)
        {
            User user = new User();
            user.EmployeeId = employeeDTO.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }
        public async Task<EnableUserReturnDTO> EnableUser(EnableUserDTO e)
        {
            int userId = e.Id;
            User u = await _userRepo.Get(userId);
            if (u == null)
                throw new NoEmployeesFoundException();
            if (e.IsEnabled == true)
            {
                u.Status = "Active";
                u = await _userRepo.Update(u);
            }
            else
            {
                u.Status = "Disabled";
                u = await _userRepo.Update(u);
            }
            EnableUserReturnDTO returnDTO = new EnableUserReturnDTO();
            returnDTO.Id = u.EmployeeId;
            returnDTO.Status = u.Status;
            return returnDTO;
        }
        public async Task<Request> RaiseRequest(RequestDTO requestDTO)
        {
            try
            {
                Request re = new Request();
                re.RequestMessage = requestDTO.RequestMessage;
                re.RequestRaisedBy = requestDTO.EmployeeId;
                re.RequestStatus = "Pending";
                re = await _requestRepo.Add(re);
                return re;
            }
            catch (Exception ex)
            {
                throw new RaiseRequestException("Unable to raise request");
            }
        }

        public async Task<IEnumerable<Request>> GetRequests(int userId)
        {
            try
            {
                var user = await _userRepo.Get(userId);
                if (user == null)
                    throw new Exception("No user with the given ID");
                if (user.Status == "Disabled")
                    throw new Exception("User is disabled");
                var employee = await _employeeRepo.Get(userId);
                if (employee == null)
                    throw new Exception("No employee with the given ID");

                if (employee.Role == "User")
                {
                    var requests = await _requestRepo.Get();
                    requests = requests.Where(r => r.RequestRaisedBy == userId);
                    requests = requests.OrderBy(r => r.RequestDate);
                    return requests;
                }
                else if (employee.Role == "Admin")
                {
                    var requests = await _requestRepo.Get();
                    requests = requests.OrderBy(r => r.RequestDate);
                    return requests;
                }
            }
            catch (Exception ex)
            {
                throw new UnableToGetRequestsException();
            }
            throw new UnableToGetRequestsException();
        }
    }
}
