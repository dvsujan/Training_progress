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
        static void countvowels(String str1 ,string  str2 )
        {
            int count1 = 0;
            int count2 = 0; 
            for (int i = 0; i< str1.Length; i++)
            {
                if (str1[i] == 'a' || str1[i] == 'e' || str1[i] == 'i' || str1[i] == 'o' || str1[i] == 'u')
                {
                    count1 += 1; 
                }
            }
            for (int i = 0; i< str2.Length; i++)
            {
                if (str2[i] == 'a' || str2[i] == 'e' || str2[i] == 'i' || str2[i] == 'o' || str2[i] == 'u')
                {
                    count2 += 1; 
                }
            }
            if (count1 < count2)
            {
                Console.WriteLine($"string {str1} with legth {count1}"); 
            }
            else if(count2 < count1)
            {
                Console.WriteLine($"string {str2} with legth {count2}"); 
            }
            else
            {
                Console.WriteLine($"both strings {str1} and {str2} have equal vowels"); 
            }

        } 
        static bool splitString(string str, out string word1, out string word2)
        {
            word1 = word2 = null;
            if (str == null)
            {
                return false;
            }
            string[] words = str.Split(',');
            if (words.Length == 0)
            {
                return false;
            }
            word1 = words[0];
            word2 = words[1];
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Question:\nTake a string from user the words seperated by comma(\",\"). Seperate the words and find the words with the least number of repeating vowels. print the count and the word. If there is a tie then print all the words that tie for the least\r\n");
            string str;
            string word1, word2;
            Console.WriteLine("Enter the string seperted with ,");
            str = Console.ReadLine();
            if (str == null)
            {
                Console.WriteLine("invlid string");
                Console.ReadLine();
                return;
            }
            splitString(str, out word1, out word2);
            countvowels(word1, word2);
            Console.ReadLine(); 
        }
    }
}