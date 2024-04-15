using System.Reflection.Metadata.Ecma335;

namespace CowBull
{
    internal class Program
    {
        /// <summary>
        /// cecks if a guess if valid 
        /// </summary>
        /// <param name="guess">guess string</param>
        /// <returns>return boolean based on the string</returns>
        static bool IsValidGuess(string guess)
        {
            for (int i = 0; i < guess.Length; i++) 
            {
                if (!char.IsLetter(guess[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// main function
        /// </summary>
        /// <param name="args">--</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("COW BULL game");

            Console.WriteLine("Enter guess word");
            string secretWord = Console.ReadLine(); 
            if(secretWord.Length!=4 || !IsValidGuess(secretWord)|| secretWord == null) {
                Console.WriteLine("not a valid guess ");
                return; 
            }
            
            Console.WriteLine("Enter 4 Letter word");
            while (true)
            {
                string guess = Console.ReadLine();

                if (guess.Length != 4 || !IsValidGuess(guess)|| guess == null)
                {
                    Console.WriteLine("Please enter a valid 4-letter word.");
                    continue;
                }

                int cows = 0, bulls = 0;
                int[] secretCounts = new int[26]; 
                int[] guessCounts = new int[26];
                for (int i = 0; i < 4; i++)
                {
                    if (secretWord[i] == guess[i])
                    {
                        cows++;
                    }
                    else
                    {
                        secretCounts[secretWord[i] - 'a'] += 1;
                        guessCounts[guess[i] - 'a'] += 1; 
                    }
                }
                
                for(int i = 0; i< 26; i++)
                {
                    bulls += Math.Min(secretCounts[i], guessCounts[i]); 
                }
                Console.WriteLine($"cows - {cows}, bulls - {bulls}");

                if (cows == 4)
                {
                    Console.WriteLine("Congratulations!!! You won!");
                    break;
                }
            }

        }

    }
       
}
