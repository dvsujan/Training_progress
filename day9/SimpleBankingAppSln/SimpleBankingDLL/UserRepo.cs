using SimpleBankingAppModels;

namespace SimpleBankingDLL
{
    public class UserRepo : IRepo<int, User>
    {
        readonly Dictionary<int, User> _users; 
        /// <summary>
        /// default constructor
        /// </summary>
        public UserRepo()
        {
            _users = new Dictionary<int, User>(); 
        }
        /// <summary>
        /// generates id for the user based on the length
        /// </summary>
        /// <returns></returns>
        public int GenerateId()
        {
            if(_users.Count == 0)
            {
                return 1; 
            }
            int id = _users.Keys.Max();
            return ++id;
        }
        /// <summary>
        /// adds new user to the dict
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public User? Add(User t)
        {
            if (_users.ContainsValue(t))
            {
                return null; 
            }
            
            t.id = GenerateId();
            _users.Add(t.id, t);
            return t;
        }
        /// <summary>
        /// deletes user from the dict
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        
        public User? Delete(int key)
        {
            if (_users.ContainsKey(key))
            {
                User? user = _users[key];
                _users.Remove(key);
                return user;
            }
            return null;
        }

        /// <summary>
        /// gets te user from the dict
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public User? Get(int key)
        {
            if (_users.ContainsKey(key))
            {
                return _users[key];
            }
            return null;
        }
        /// <summary>
        /// gets all users form the dict
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return _users.Values.ToList();
        }
        /// <summary>
        /// updates the user from dict
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public User? Update(User item)
        {
            if (_users.ContainsKey(item.id))
            {
                _users[item.id] = item;
                return item;
            }
            return null;
        }
    }
}
