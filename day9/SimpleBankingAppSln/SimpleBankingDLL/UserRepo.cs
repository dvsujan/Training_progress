using SimpleBankingAppModels;

namespace SimpleBankingDLL
{
    public class UserRepo : IRepo<int, User>
    {
        readonly Dictionary<int, User> _users; 
        public UserRepo()
        {
            _users = new Dictionary<int, User>(); 
        }
        public int GenerateId()
        {
            if(_users.Count == 0)
            {
                return 1; 
            }
            int id = _users.Keys.Max();
            return ++id;
        }
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

        public User? Get(int key)
        {
            if (_users.ContainsKey(key))
            {
                return _users[key];
            }
            return null;
        }

        public List<User> GetAll()
        {
            return _users.Values.ToList();
        }

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
