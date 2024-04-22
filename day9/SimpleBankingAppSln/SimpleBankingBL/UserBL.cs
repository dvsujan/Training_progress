using SimpleBankingDLL;
using SimpleBankingAppModels;
using SimpleBankingBL.Exceptions; 
namespace SimpleBankingBL
{
    public class UserBL : IUserService
    {
        readonly IRepo<int, User> _userRreposotory; 
        /// <summary>
        /// default constrcutror 
        /// </summary>
        public UserBL()
        {
            _userRreposotory = new UserRepo() ; 
        }
        /// <summary>
        /// adds new user to the db
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user) => _userRreposotory.Add(user);
        /// <summary>
        /// changes password fo the user 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFloundException"></exception>

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
        /// <summary>
        /// deletes user from db
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFloundException"></exception>

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
    /// <summary>
    /// gets all user from db
    /// </summary>
    /// <returns></returns>
        public List<User> getAllUsers()
        {
            return _userRreposotory.GetAll();
        }
        /// <summary>
        /// logs in new user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFloundException"></exception>

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
        /// <summary>
        /// logout the user
        /// </summary>
        /// <returns></returns>

        public bool LogoutUser()
        {
            return true;  
        }
        /// <summary>
        /// register new user to the db
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="UserAlreadyExistsException"></exception>
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
