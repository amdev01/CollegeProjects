using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciWRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many Fibonacci numbers you want to enter:");
            string console = Console.ReadLine();
            int Num;
            while (!int.TryParse(console, out Num))
            {
                Console.WriteLine("Enter how many Fibonacci numbers you want to enter:");
                console = Console.ReadLine();
            }
            Fibo(0, 1, 0, Num, 0);
            Console.ReadKey();
        }

        static void Fibo(int prev, int cur, int tmp, int length, int counter)
        {
            tmp = prev + cur;
            prev = cur;
            cur = tmp;
            Console.WriteLine($" {tmp} ");
            if (counter < length-1) Fibo(prev, cur, tmp, length, ++counter);
        }
    }
}
