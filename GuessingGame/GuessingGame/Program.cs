using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static int iRandom;
        static int guess;
        static void Main(string[] args)
        {
            Console.WriteLine("********* Welcome to the guessing number game *********");
            Console.WriteLine("***** You have to guess a number between 1 and 50 *****");
            var random = new Random();
            iRandom = random.Next(50);
            Console.WriteLine("Your guess: ");
            guess = Convert.ToInt16(Console.ReadLine());
            while (guess != iRandom)
            {
                if (guess > iRandom)
                {
                    Console.WriteLine("Your number is too high! Try again ");
                }
                else if (guess < iRandom)
                {
                    Console.WriteLine("Your number is too low! Try again ");
                }
                else if (guess > 50 || guess < 0)
                {
                    Console.WriteLine("Guess has to be in the 1 to 50 range");
                }
                else
                {
                    Console.WriteLine("Incorrect Input");
                }
                Console.WriteLine("Your guess: ");
                guess = Convert.ToInt16(Console.ReadLine());
            }
            Console.WriteLine(" Press Any Key To Exit");
            Console.Read();
        }
    }
}
