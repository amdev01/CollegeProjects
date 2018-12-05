using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLengthC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string mString = Console.ReadLine();
            Console.WriteLine($"Size is {stringLength(mString)}");
            Console.WriteLine("Enter the charcter you want to find: ");
            char mChar = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"Index of {mChar} is {indexOf(mString,mChar)}");
            Console.WriteLine($"Upper index {toUpper(mString)} ");
            Console.Read();
        }

        static int stringLength(string mString)
        {
            int size = 0;
            char? character = mString[0];
            while (character != null)
            {
                size++;
                try
                {
                    character = mString[size];
                }
                catch (Exception e)
                {
                    character = null;
                }
            }
            return size;
        }

        static int? indexOf(string inputString, char character)
        {
            for (int i = 0; i < stringLength(inputString); i++)
            {
                if (inputString[i] == character)
                {
                    return i;
                }
            }
            return null;
        }

        static string toUpper(string inputString)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ret = "";
            for (int i = 0; i < stringLength(inputString); i++)
            {
                int? index = indexOf(alphabet, inputString[i]);
                if (index != null)
                {
                    ret += upperAlphabet[Convert.ToInt16(index)];
                }
                else
                {
                    ret += inputString[i];
                }
            }
            return ret;
        }
    }
}
