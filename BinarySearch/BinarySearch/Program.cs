using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random ran = new Random();
            for (int i = 0; i < 20; i++)
            {
                list.Add(ran.Next(0, 50));
            }

            list.Sort();
            int toSearch;
            int.TryParse(Console.ReadLine(), out toSearch);
            int min = 0;
            int max = list.Count();
            int Mid = (min + max)/2;
            while(list[Mid] != toSearch)
            {
                if (list[Mid] > toSearch)
                {
                    max = Mid - 1;
                    Mid = (min + max) / 2;
                }
                else if (list[Mid] < toSearch)
                {
                    min = Mid + 1;
                    Mid = (min + max) / 2;
                }
                else { Console.WriteLine($"{toSearch} found at index {Mid}"); break; };
            }
            Console.Read();
        }

    }
}
