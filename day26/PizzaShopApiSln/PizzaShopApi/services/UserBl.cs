using EmployeeRequestTrackerAPI.Interfaces;
using PizzaShopApi.Exceptions;
using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;
using PizzaShopApi.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaShopApi.services
{
    public class UserBl : IUserService
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly ITokenService _tokenser;
        
        public UserBl(IRepo<int, User> userRepo, ITokenService _tokenser)
        {
            _userRepo = userRepo;
            this._tokenser = _tokenser;
        }
        
        public async Task<LoginReturnDTO> Login(UserLoginDTO user)
        {
            var userDB = await _userRepo.GetById(user.Id);
            if (userDB == null)
            {
                throw new Exception("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.HashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                userDB.Status = User.status.Active;
                await _userRepo.Update(userDB);
                LoginReturnDTO loginReturnDTO = UserToLoginReturn(userDB);
                return loginReturnDTO;
                throw new Exception("Your account is not activated");
            }
            throw new Exception("Invalid username or password");
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

        public LoginReturnDTO UserToLoginReturn(User user)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO();
            loginReturnDTO.userId = user.Id;
            loginReturnDTO.Token = _tokenser.GenerateToken(user);
            return loginReturnDTO;
        }

        public async Task<User> Register(userRegisterDTO user)
        {
            User RegUser = null;
            try
            {
                RegUser = new User();
                RegUser.Name = user.Name;
                RegUser.Email = user.Email;
                RegUser.Status = User.status.Inactive;
                HMACSHA512 hMACSHA = new HMACSHA512();
                RegUser.HashKey = hMACSHA.Key;
                RegUser.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                return await _userRepo.Add(RegUser);
            }
            catch (Exception e) { }
            if (RegUser != null)
            {
                 await RevertUserInsert(RegUser);
            }
            throw new Exception("Error while registering user");
        }
        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.Id);
        }
    }
}
