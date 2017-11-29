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
            while (gamemode != "2" && gamemode != "1")
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

        /* ================== General methods ================== */
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

        static string freeIndex(char[] board)
        {
            string freeI = null;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    freeI += i + 1 + " ";
                }
            }
            return freeI;
        }

        static int? getRandom()
        {
            int? iRandom = null;
            if (freeIndex(boardValues) != null)
            {
                Random random = new Random();
                iRandom = random.Next(0, 10);
                while (!freeIndex(boardValues).Contains(iRandom.ToString()))
                {
                    iRandom = random.Next(0, 10);
                }
            }
            return iRandom - 1;
        }

        static bool checkWinner(char who, char[] board)
        {
            if ((board[0] == who && board[1] == who && board[2] == who) ||
            (board[3] == who && board[4] == who && board[5] == who) ||
            (board[6] == who && board[7] == who && board[8] == who) ||
            (board[0] == who && board[3] == who && board[6] == who) ||
            (board[1] == who && board[4] == who && board[7] == who) ||
            (board[2] == who && board[5] == who && board[8] == who) ||
            (board[0] == who && board[4] == who && board[8] == who) ||
            (board[2] == who && board[4] == who && board[6] == who))
            {
                Console.WriteLine($"{who} won!");
                return true;
            }
            return false;
        }

        /* ================== Human user ================== */
        static bool UserInput(char who)
        {
            if (freeIndex(boardValues) != null)
            {
                Console.WriteLine($"Enter the position to put {who} in (free positions: {freeIndex(boardValues)})");
                string input = Console.ReadLine();
                while (!freeIndex(boardValues).Contains(input) || input == " " || input == "")
                {
                    Console.WriteLine($"Index {input} is not within the {freeIndex(boardValues)}range");
                    input = Console.ReadLine();
                }
                boardValues[int.Parse(input) - 1] = who;
                updateBoard();
                someoneWon = checkWinner(who, boardValues);
                return true;
            }
            updateBoard();
            Console.WriteLine("Draw");
            return false;
        }

        /* ================== AI ================== */
        static void machinePlay()
        {
            Console.WriteLine("Easy(1) Medium(2) Hard(3)");
            string level = Console.ReadLine();
            while (level != "2" && level != "1" && level != "3")
            {
                Console.WriteLine($"Incorrect input {level} (1|2|3)");
                level = Console.ReadLine();
            }
            switch (level)
            {
                case "1":
                    updateBoard();
                    while (!someoneWon)
                    {
                        if (!UserInput('X') || someoneWon)
                            break;
                        if (!ComputerInput('O', level) || someoneWon)
                            break;
                    }
                    break;
                case "2":
                    while (!someoneWon)
                    {
                        updateBoard();
                        if (!UserInput('X') || someoneWon)
                            break;
                        if (!ComputerInput('O', level) || someoneWon)
                            break;
                    }
                    break;
                case "3":
                    while (!someoneWon)
                    {
                        updateBoard();
                        if (!UserInput('X') || someoneWon)
                            break;
                        if (!ComputerInput('O', level) || someoneWon)
                            break;
                    }
                    break;
            }
        }

        /* ========= Easy - Medium - Hard ========= */
        /*
        Easy:
           O is being placed in random position.
        Medium:
           Check all empty spaces for next move of O,
           if one of them is winning, place O in there
           otherwise place it in any free random position.
        Hard:
           Extension of medium, it checks if users next move
           could be winning and places O to block them, otherwise
           runs medium level alorithm.
         */

        static void winningId(char[] copyBoard, char who, int id, ref int c, ref int? space)
        {
            copyBoard[id] = who;
            if (checkWinner(who, copyBoard))
            {
                space = id;
                c = 0;
            }
        }

        static bool ComputerInput(char who, string level)
        {
            if (freeIndex(boardValues) != null)
            {
                int c = -1;
                int? xwin = null, owin = null;
                if (level == "2" || level == "3")
                {
                    int[] freeArray = Array.ConvertAll(freeIndex(boardValues).Split(default(string[]), StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s) - 1);
                    foreach (int id in freeArray)
                    {
                        winningId(boardValues.ToArray(), 'O', id, ref c, ref owin);
                        if (level == "3")
                            winningId(boardValues.ToArray(), 'X', id, ref c, ref xwin);
                    }
                    if (owin != null)
                        boardValues[owin.Value] = 'O';
                    else if (owin == null && xwin != null && level == "3")
                        boardValues[xwin.Value] = 'O';
                }
                if (c == -1)
                {
                    int? comp;
                    if ((comp = getRandom()) != null)
                        boardValues[comp.Value] = who;
                }
                updateBoard();
                someoneWon = checkWinner(who, boardValues);
                return true;
            }
            updateBoard();
            Console.WriteLine("Draw");
            return false;
        }

        /* ========= Hard (MiniMax) ========= */
        // TODO
    }
}