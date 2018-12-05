using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factorial Calculator: Enter a number");
            string console = Console.ReadLine();
            Int64 Num;
            while (!Int64.TryParse(console, out Num))
            {
                Console.WriteLine($"{Num} is  not a number");
                console = Console.ReadLine();
            }
            Factorial(Num, Num - 1, Num);
            Console.ReadLine();
        }

        static void Factorial(Int64 Num, Int64 newN, Int64 backup)
        {
            Num *= newN;
            if (newN > 1) Factorial(Num, --newN, backup);
            else Console.WriteLine($"{backup}!={Num}");
        }
    }
}
