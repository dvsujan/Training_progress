using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;


namespace FirstFrameWorkApp {

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question:\nFind the length of the given user's name");
            Console.WriteLine("Enter your name"); 
            string username = Console.ReadLine();
            Console.WriteLine($"The lengthof the given user's name is {username.Length}");
            Console.ReadLine(); 
        }
    }
}