using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] Table = null;
            int nOt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("MENU: Enter 1 to set up teams, 2 to display teams, 3 to resise group");
                string action = Console.ReadLine();
                while (action != "1" && action != "2" && action != "3") action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        if (Table == null) setUpTable(ref Table, ref nOt);
                        else Console.WriteLine("Table is not empty!");
                        break;
                    case "2":
                        display(Table);
                        break;
                    case "3":
                        if (Table != null)
                        {
                            int newC;
                            Console.WriteLine("How many new teams do you want to add?");
                            string console = Console.ReadLine();
                            while (!int.TryParse(console, out newC))
                            {
                                Console.WriteLine($"{console} is not a number! Enter the number of teams you want add!");
                                console = Console.ReadLine();
                            }
                            ArrayResize2D(ref Table, Table.GetLength(0) + newC);
                        }
                        else Console.WriteLine("Table does not exist!");
                        break;
                }

                Console.WriteLine("Do you want to exit? y/n");
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Y) exit = true;
            }
            Console.ReadKey();
        }

        static void setUpTable(ref string[,] Table, ref int nOt)
        {
            Console.WriteLine("Setting up number of elements . . .");
            Console.WriteLine("Enter the number of teams you want");
            string console = Console.ReadLine();
            while (!int.TryParse(console, out nOt))
            {
                Console.WriteLine($"{console} is not a number! Enter the number of teams you want");
                console = Console.ReadLine();
            }
            Console.WriteLine("Setting the table up . . .");
            Table = new string[nOt, 3];
            Console.WriteLine("Fill in the table . . .");
            for (int i = 0; i < nOt; i++)
            {
                Console.WriteLine($"Currently on Team {i + 1} out of {nOt}");
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Enter column {j + 1}, 1 - Name, 2 - Games played, 3 - Points:");
                    if (j != 0)
                    {
                        string consoleL = Console.ReadLine();
                        while (!int.TryParse(consoleL, out int tmp))
                        {
                            Console.WriteLine($"{consoleL} is not a number! Try again:");
                            consoleL = Console.ReadLine();
                        }
                        Table[i, j] = consoleL;
                    }
                    else Table[i, j] = Console.ReadLine();
                }
            }
        }

        static void display(string[,] Table)
        {
            Console.WriteLine(" Team Name----Games played----Points");
            string row;
            if (Table != null)
            {
                for (int i = 0; i < Table.GetLength(0); i++)
                {
                    row = "";
                    for (int j = 0; j < 3; j++) row += " " + Table[i, j] + " ";
                    Console.WriteLine($"{row}");
                }
            }
        }

        static void ArrayResize2D(ref string[,] OGArray, int newC)
        {
            string[,] tmp = (string[,])OGArray.Clone();
            //OGArray = null;
            OGArray = new String[newC, 3];
            for (int i = 0; i < OGArray.GetLength(0); i++)
            {
                if (i < tmp.GetLength(0))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        OGArray[i, j] = tmp[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"NEW ENTRY AFTER RESISE: Enter column {j + 1}, 1 - Name, 2 - Games played, 3 - Points:");
                        if (j != 0)
                        {
                            string console = Console.ReadLine();
                            while (!int.TryParse(console, out int tmpi))
                            {
                                Console.WriteLine($"{console} is not a number! Try again:");
                                console = Console.ReadLine();
                            }
                            OGArray[i, j] = console;
                        }
                        else OGArray[i, j] = Console.ReadLine();
                    }
                }
            }
        }
    }
}