using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNamesTable
{
    class Student
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> Table = new List<Student>();
            int nOt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("MENU: Enter 1 to intup student details, 2 to display student details, 3 to resize student group");
                string action = Console.ReadLine();
                while (action != "1" && action != "2" && action != "3" && action != "4") action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        if (Table.Count() == 0) setUpTable(ref Table, ref nOt);
                        else Console.WriteLine("Table is not empty!");
                        break;
                    case "2":
                        display(Table);
                        break;
                    /*case "3":
                        if (Table != null)
                        {
                            int newC;
                            Console.WriteLine("How many new students do you want to add?");
                            string console = Console.ReadLine();
                            while (!int.TryParse(console, out newC))
                            {
                                Console.WriteLine($"{console} is not a number! Enter the number of teams you want add!");
                                console = Console.ReadLine();
                            }
                            ArrayResize2D(ref Table, Table.GetLength(0) + newC);
                        }
                        else Console.WriteLine("Table does not exist!");
                        break;*/
                    case "4":
                        Console.WriteLine("Enter the sort type 1,2,3:");
                        ArraySort(ref Table, );
                        break;
                }

                Console.WriteLine("Do you want to exit? y/n");
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Y) exit = true;
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void setUpTable(ref List<Student> Table, ref int nOt)
        {
            Console.WriteLine("Setting up number of elements . . .");
            Console.WriteLine("Enter the number of students you want");
            string console = Console.ReadLine();
            while (!int.TryParse(console, out nOt))
            {
                Console.WriteLine($"{console} is not a number! Enter the number of teams you want");
                console = Console.ReadLine();
            }
            Console.WriteLine("Setting the table up . . .");
            Console.WriteLine("Fill in the table . . .");
            for (int i = 0; i < nOt; i++)
            {
                string[] tmpRow = new string[3];
                Console.WriteLine($"Currently on Student {i + 1} out of {nOt}");
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Enter column {j + 1}, 1 - First Name, 2 - Surname, 3 - Address:");
                    tmpRow[j] = Console.ReadLine();
                }
                Table.Add(new Student {
                    FirstName = tmpRow[0],
                    Surname = tmpRow[1],
                    Address = tmpRow[2]
                });
            }
        }

        static void display(List<Student> Table)
        {
            Console.WriteLine(" First Name----Surname----Address");
            string row;
            if (Table != null)
            {
                for (int i = 0; i < Table.Count(); i++)
                {
                    Console.WriteLine($"{Table[i].FirstName + " " + Table[i].Surname + " " + Table[i].Address}");
                }
            }
        }

        /*static void ArrayResize2D(ref List<string>[,] OGArray, int newC)
        {
            List<string>[,] tmp = (List<string>[,])OGArray.Clone();
            //OGArray = null;
            OGArray = new List<string>[newC, 3];
            for (int i = 0; i < OGArray.GetLength(0); i++)
            {
                if (i < tmp.GetLength(0)) for (int j = 0; j < 3; j++) OGArray[i, j].Add((tmp[i, j]).ToString());
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"NEW ENTRY AFTER RESIZE: Enter column {j + 1}, 1 - First Name, 2 - Surname, 3 - Address:");
                        OGArray[i, j].Add(Console.ReadLine());
                    }
                }
            }
        }*/

        static void ArraySort(ref List<Student> table, int sortByIndex)
        {
            switch (sortByIndex)
            {
                case 1:
                    table.OrderBy(x => x.FirstName);
                    break;
                case 2:
                    table.OrderBy(x => x.Surname);
                    break;
                case 3:
                    table.OrderBy(x => x.Address);
                    break;
            }
        }
    }
}
