using Day8Learning;
using Microsoft.VisualBasic.FileIO;

namespace Day8Learning
{
        public struct Student
        {
            public int id;
            public string name;
            public string address;
            public string email;
            public string phone;
        }
        public record StudentRecord(int id, string name, string address, string email, string phone);


    public class IndexerClass
    {

        private string[] names = new string[10];
        public string this[int index]
        {
            get
            {
                if(index < 0 || index >= names.Length)
                {
                    return null; 
                }
                return names[index];
            }
            set
            {
                if (index >= 0 && index < names.Length)
                    names[index] = value.ToString();
                }
            }
             public override string ToString()
             {
                string str = "[";
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] != null)
                    {
                        str += names[i] + ",";
                    }
                }
                str += "]";
                return str;
             }
            }       
    
    public class Program
    {
        void UnderstandingJaggedArray()
        {
            string[][] posts = new string[4][];
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine("Please enter the number of columns");
                int count = Convert.ToInt32(Console.ReadLine());
                posts[i] = new string[count];
                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine($"Please enter the post {i + 1} value");
                    posts[i][j] = Console.ReadLine();
                }
            }
            Console.WriteLine("Posts");
            for (int i = 0; i < posts.Length; i++)
            {
                for (int j = 0; j < posts[i].Length; j++)
                    Console.Write(posts[i][j] + " ");
                Console.WriteLine("---------------------");
            }
        }
        static void Main(string[] args)
        {
            int c; 
            try
            {
                int a = 10;
                int b  = 0;
                c =  a / b;
                Console.WriteLine(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception occured: ");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Final code block");
            }
        }
    }
}
