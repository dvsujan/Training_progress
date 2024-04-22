using SimpleBankingBL;
using SimpleBankingAppModels;
using SimpleBankingBL.Exceptions;
using SimpleBankingBL;

namespace SimpleBankingApp
{
    internal class Program
    {
        static int getIntInput()
        {
            int id; 
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer");
            }
            return id;  
        }
        static float getFloatInput()
        {
            float id; 
            while (!float.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid float");
            }
            return id; 
        }
        public static UserBL userBL = new UserBL();
        public static AccountBL AccountBL = new AccountBL();
        public static void userMenu()
        {
            User LoggedInUser = null; 
            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Statement");
                Console.WriteLine("6. Get Account Balance ");
                Console.WriteLine("7. Logout");
                Console.WriteLine("Enter your choice: ");
                int choice = getIntInput();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();
                        try
                        {
                            LoggedInUser = userBL.LoginUser(email, password);
                            Console.WriteLine("Login successful");
                            Console.WriteLine("Welcome " + LoggedInUser.name);
                        }
                        catch (UserNotFloundException)
                        {
                            Console.WriteLine("Invalid email or password");
                        }
                        break;
                    
                    case 2:
                        if (LoggedInUser == null)
                        {
                            Console.WriteLine("Please login first");
                            break;
                        }
                        Console.WriteLine("Enter amount you want to deposite: ");
                        float amount = getFloatInput();
                        try
                        {
                            Account ac = AccountBL.Deposit(LoggedInUser.accountId, amount);
                            Console.WriteLine("Amount deposited successfully");
                            Console.WriteLine("Balance: " + ac.Balance);
                        }
                        catch (UserNotFloundException)
                        {
                            Console.WriteLine("User not found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter amount to withdraw: ");
                        if(LoggedInUser == null)
                        {
                            Console.WriteLine("Please login first");
                            break;
                        }
                        float withdrawAmount = getFloatInput();
                        Console.WriteLine(LoggedInUser); 
                        try{
                            Account withdrawAcc = AccountBL.Withdraw(LoggedInUser.accountId, withdrawAmount);
                            Console.WriteLine("Amount withdrawn successfully");
                            Console.WriteLine("Balance: " + withdrawAcc.Balance);
                        }
                        catch (UserNotFloundException)
                        {
                            Console.WriteLine("User not found");
                        }
                        catch (InsufficientBalanceException)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 4:
                        if(LoggedInUser == null)
                        {
                            Console.WriteLine("Please login first");
                            break;
                        }
                        Console.WriteLine("Enter receiver Account No: ");
                        int receiverId = getIntInput(); 
                        Console.WriteLine("Enter amount: ");
                        float transferAmount = getFloatInput();
                        try
                        {
                            Account senderAccount = AccountBL.Transfer(LoggedInUser.accountId, receiverId , transferAmount);
                            Console.WriteLine("Amount transferred successfully");
                            Console.WriteLine("Balance: " + senderAccount.Balance);
                        }
                        catch (UserNotFloundException)
                        {
                            Console.WriteLine("User not found");
                        }
                        catch (InsufficientBalanceException)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        break;
                    case 5:
                        if(LoggedInUser == null)
                        {
                            Console.WriteLine("Please login first");
                            break;
                        }
                        List<Transaction> transactions = AccountBL.TransactionsOfUser(LoggedInUser.accountId);
                        foreach (Transaction transaction in transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        break;
                    case 6:
                        if(LoggedInUser == null)
                        {
                            Console.WriteLine("Please login first");
                            break;
                        }
                        try
                        {
                            Account account = AccountBL.GetAccount(LoggedInUser.accountId);
                            Console.WriteLine("Balance: " + account.Balance);
                        }
                        catch (UserNotFloundException)
                        {
                            Console.WriteLine("User not found");
                        }
                        break;
                    case 7:
                        return; 
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Create new Account");
                Console.WriteLine("2. View all users");
                Console.WriteLine("3. View all transactions");
                Console.WriteLine("4. Logout");
                Console.WriteLine("Enter your choice: ");
                int choice = getIntInput();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();
                        Console.WriteLine("Minium Balance 5000\n ");
                        string choice1 = Console.ReadLine();
                        User user = new User(name, email, password, -1);
                        Account account = new Account();
                        try
                        {
                            User u = userBL.AddUser(user);
                            account.UserId = u.id;
                            account.Balance = 5000;
                            Account a = AccountBL.CreateAccount(account);
                            u.accountId = a.id;
                            User user1 = userBL.UpdateUser(u);
                            Console.WriteLine("User registered successfully");
                            Console.WriteLine(user1);
                            Console.WriteLine("Account Details: ");
                            Console.WriteLine(a);
                        }
                        catch (UserAlreadyExistsException)
                        {
                            Console.WriteLine("User already exists");
                        }
                        break;

                    case 2:
                        List<User> users = userBL.getAllUsers();
                        foreach (var u in users)
                        {
                            Console.WriteLine(u);
                        }
                        break;
                    case 3:
                        List<Transaction> transactions = AccountBL.getAllTransactions();
                        foreach (Transaction transaction in transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }   
        static bool LoginInAdmin()
        {
            Console.WriteLine("Enter admin username: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter admin password: ");
            string password = Console.ReadLine();
            if (email == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }   
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. User");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = getIntInput(); 
                switch (choice)
                {
                    case 1:
                        userMenu();
                        break;
                    case 2:
                        if (LoginInAdmin())
                        {
                            Console.WriteLine("Admin login successful");
                            AdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid email or password");
                        }
                        break; 
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
