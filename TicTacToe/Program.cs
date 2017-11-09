using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /*
     *  Grid design:
     *    _______
     *    |X|X|O|
     *    --|-|--
     *    |O|X|O|
     *    --|-|--
     *    |X|O|X|
     *    -------
     */
    class Program
    {
        static char[] boardValues = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static bool someoneWon = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to play with a friend or with the computer? (1|2)");
            string gamemode = Console.ReadLine();
            int igamemmode;
            while (!int.TryParse(gamemode, out igamemmode) || igamemmode > 2 || igamemmode < 1)
            {
                Console.WriteLine($"Incorrect input {gamemode} (1|2)");
                gamemode = Console.ReadLine();
            }
            switch (gamemode)
            {
                case "1":
                    twoPlayers();
                    break;
                case "2":
                    machinePlay();
                    break;
            }
            Console.ReadKey();
        }
        static void twoPlayers()
        {
            updateBoard();
            while (!someoneWon)
            {
                if (!UserInput('X') || someoneWon)
                    break;
                if (!UserInput('O') || someoneWon)
                    break;
            }
        }
        static void machinePlay()
        {
            updateBoard();
            while (!someoneWon)
            {
                if (!UserInput('X') || someoneWon)
                    break;
                if (!ComputerInput('O') || someoneWon)
                    break;
            }
        }
        static void updateBoard()
        {
            Console.Clear();
            Console.WriteLine("_______");
            Console.WriteLine($"|{boardValues[0]}|{boardValues[1]}|{boardValues[2]}|");
            Console.WriteLine("--|-|--");
            Console.WriteLine($"|{boardValues[3]}|{boardValues[4]}|{boardValues[5]}|");
            Console.WriteLine("--|-|--");
            Console.WriteLine($"|{boardValues[6]}|{boardValues[7]}|{boardValues[8]}|");
            Console.WriteLine("-------");
        }
        static bool UserInput(char who)
        {
            if (freeIndex() != null)
            {
                Console.WriteLine($"Enter the position to put {who} in (free positions: {freeIndex()})");
                string input = Console.ReadLine();
                while (!freeIndex().Contains(input) || input == " " || input == "")
                {
                    Console.WriteLine($"Index {input} is not within the {freeIndex()}range");
                    input = Console.ReadLine();
                }
                boardValues[int.Parse(input) - 1] = who;
                updateBoard();
                someoneWon = checkWinner(who);
                return true;
            }
            updateBoard();
            Console.WriteLine("Draw");
            return false;
        }
        static bool ComputerInput(char who)
        {
            if (freeIndex() != null)
            {
                int? comp;
                if ((comp = getRandom()) != null)
                {
                    boardValues[comp.Value] = who;
                }
                updateBoard();
                someoneWon = checkWinner(who);
                return true;
            }
            updateBoard();
            Console.WriteLine("Draw");
            return false;
        }
        static string freeIndex()
        {
            string freeI = null;
            for (int i = 0; i < boardValues.Length; i++)
            {
                if (boardValues[i] == ' ')
                {
                    freeI += i + 1 + " ";
                }
            }
            return freeI;
        }
        static int? getRandom()
        {
            int? iRandom = null;
            if (freeIndex() != null)
            {
                Random random = new Random();
                iRandom = random.Next(0, 10);
                while (!freeIndex().Contains(iRandom.ToString()))
                {
                    iRandom = random.Next(0, 10);
                }
            }
            return iRandom - 1;
        }
        static bool checkWinner(char who)
        {
            if ((boardValues[0] == who && boardValues[1] == who && boardValues[2] == who) ||
            (boardValues[3] == who && boardValues[4] == who && boardValues[5] == who) ||
            (boardValues[6] == who && boardValues[7] == who && boardValues[8] == who) ||
            (boardValues[0] == who && boardValues[3] == who && boardValues[6] == who) ||
            (boardValues[1] == who && boardValues[4] == who && boardValues[7] == who) ||
            (boardValues[2] == who && boardValues[5] == who && boardValues[8] == who) ||
            (boardValues[0] == who && boardValues[4] == who && boardValues[8] == who) ||
            (boardValues[2] == who && boardValues[4] == who && boardValues[6] == who))
            {
                Console.WriteLine($"{who} won!");
                return true;
            }
            return false;
        }
    }
}
