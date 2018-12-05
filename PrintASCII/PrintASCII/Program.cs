using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            ASCII(0);
            Console.ReadKey();
        }

        static void ASCII(int i)
        {
            char c = Convert.ToChar(i);
            //string s = Encoding.ASCII.GetString(new byte[] { byte.Parse(i.ToString()) });
            Console.WriteLine($"Num - {i} ASCII - {c}");
            if (i < 255) ASCII(++i);
        }
    }
}
