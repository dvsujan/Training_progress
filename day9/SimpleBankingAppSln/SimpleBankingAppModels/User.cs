namespace SimpleBankingAppModels
{
    public class User
    {
        public int id { get; set;}
        public string name { get; set;}
        public string email { get; set;}
        public string password { get; set;}
        public int accountId { get; set; }
        public User()
        {
            id = -1;
            name = String.Empty; 
            email = String.Empty;
            password = String.Empty;
            accountId = -1;
        }
        public User(string name, string email, string password, int accountId)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.accountId = accountId;
        }
        public override bool Equals(object? obj)
        {
            return this.id.Equals(((User)obj).id);
        }
        public override string ToString()
        {
            return $"User Id: {id}, Name: {name}, Email: {email}, Password: {password}, Account Id: {accountId}";
        }
    }
}
