using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;


namespace FirstFrameWorkApp
{

    internal class Program
    {
        static bool validatePassword(string username , string password)
        {
            if(username == "ABC" && password == "123")
            {
                return true; 
            }
            return false; 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Questoin:\n Create a application that will take username and password from user. check if username is \"ABC\" and passwod is \"123\". \r\nPrint error message if username or password is wrong\r\nAllow user 3 attemts.\r\nAfter 3rd attempt if user enters invalid credentials then print msg to intimate user taht he/she has exceeded the number of attempts and stop\r\n");
            int attempts = 3;
            bool loggedIn = false;
            while (attempts >= 1)
            {
                Console.WriteLine("Attempts Left: " + attempts);
                string username, password;
                Console.WriteLine("enter Username");
                username = Console.ReadLine();
                Console.WriteLine("enter Password");
                password = Console.ReadLine();
                if (validatePassword(username, password))
                {
                    Console.WriteLine("Login Successful");
                    loggedIn = true;
                    break;
                }
                Console.WriteLine("InCorrect password Try again !");
                attempts--;
            }
            if (!loggedIn)
            {
                Console.WriteLine("you ran out of attempts cannot login");
            }
            Console.ReadLine();
        }
    }
}