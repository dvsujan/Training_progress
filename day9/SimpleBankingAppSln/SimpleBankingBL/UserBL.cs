using SimpleBankingDLL;
using SimpleBankingAppModels;
using SimpleBankingBL.Exceptions; 
namespace SimpleBankingBL
{
    public class UserBL : IUserService
    {
        readonly IRepo<int, User> _userRreposotory; 
        public UserBL()
        {
            _userRreposotory = new UserRepo() ; 
        }
        public User AddUser(User user) => _userRreposotory.Add(user);

        public User ChangePassword(string email, string oldPassword, string newPassword)
        {
            List<User> users = _userRreposotory.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].email == email && users[i].password == oldPassword)
                {
                    users[i].password = newPassword;
                    return users[i];
                }
            }
            throw new UserNotFloundException(); 
        }

        public User DeleteUser(string email, string password)
        {
            List<User> users = _userRreposotory.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].email == email && users[i].password == password)
                {
                    User u = users[i];
                    _userRreposotory.Delete(users[i].id);
                    return u;
                }
            }
            throw new UserNotFloundException();
        }

        public List<User> getAllUsers()
        {
            return _userRreposotory.GetAll();
        }

        public User LoginUser(string email, string password)
        {
            List<User> users = _userRreposotory.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].email == email && users[i].password == password)
                {
                    return users[i];
                }
            }
            throw new UserNotFloundException();
        }

        public bool LogoutUser()
        {
            return true;  
        }

        public User RegisterUser(string name, string email, string password)
        {
            List<User> users = _userRreposotory.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].email == email)
                {
                    throw new UserAlreadyExistsException();
                }
            }
            User user = new User(name, email, password, -1);
            _userRreposotory.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            return _userRreposotory.Update(user);
        }
    }
}
