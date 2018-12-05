using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static long numOfnums;
        static string snumOfnums;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount of Fibonacci numbers to be output > ");
            snumOfnums = Console.ReadLine();
            while (!IsDigitsOnly(snumOfnums))
            {
                Console.WriteLine("Input should be an integer! > ");
                snumOfnums = Console.ReadLine();
            }
            try
            {
                numOfnums = Convert.ToInt64(snumOfnums);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
                Console.WriteLine("Hey, I can't numbers so big, make me smaller!");
            }

            int prev = 0;
            int curr = 1;
            int tmp = 0;
            for (int i = 0; i < numOfnums; i++ ) {
                tmp = prev + curr;
                prev = curr;
                curr = tmp;
                Console.WriteLine(" {0} ", tmp);
            }
            Console.ReadLine();
        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
