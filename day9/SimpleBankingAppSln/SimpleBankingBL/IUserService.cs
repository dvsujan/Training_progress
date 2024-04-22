using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingAppModels;

namespace SimpleBankingBL
{
    public interface IUserService
    {
        public User RegisterUser(string name, string email, string password);
        public User LoginUser(string email, string password);
        public bool LogoutUser();
        public  User ChangePassword(string email, string oldPassword, string newPassword);
        public User DeleteUser(string email, string password);
    }
}
