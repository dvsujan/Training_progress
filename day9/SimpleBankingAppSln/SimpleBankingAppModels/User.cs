namespace SimpleBankingAppModels
{
    public class User
    {
        public int id { get; set;}
        public string name { get; set;}
        public string email { get; set;}
        public string password { get; set;}
        public int accountId { get; set; }
        /// <summary>
        /// default constructor for the user model
        /// </summary>
        public User()
        {
            id = -1;
            name = String.Empty; 
            email = String.Empty;
            password = String.Empty;
            accountId = -1;
        }
        /// <summary>
        /// paramterized constructor for the user model
        /// </summary>
        /// <param name="name"> name of the user</param>
        /// <param name="email">email of the user</param>
        /// <param name="password">password of the user</param>
        /// <param name="accountId">account id</param>
        public User(string name, string email, string password, int accountId)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.accountId = accountId;
        }
        /// <summary>
        /// overrides the equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return this.id.Equals(((User)obj).id);
        }
        /// <summary>
        /// overrides the ToString method to make this object as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"User Id: {id}, Name: {name}, Email: {email}, Password: {password}, Account Id: {accountId}";
        }
    }
}
