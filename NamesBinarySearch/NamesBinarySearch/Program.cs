using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamesBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Saul", "Adam", "Harrison", "Alex", "Jack", "Cal", "John", "Mitch", "Bob", "Harry" };
            printAr(names);
            //Array.Sort(names);
            BubbleSort(ref names);
            printAr(names);

            Console.WriteLine("Enter a name to find:");
            string toFind = Console.ReadLine();
            int ret = BinarySearch(names.Count(), 0, ref names, toFind);
            if (ret == -1)
                Console.WriteLine(" No item found!!");
            else
                Console.WriteLine(" index {0}:  {1}", ret, names[ret]);
            Console.ReadKey();
        }

        static void printAr(string[] names)
        {
            string snames = "";
            foreach (string name in names)
            {
                snames += name + ", ";
            }
            Console.WriteLine(snames);
        }

        static void BubbleSort(ref string[] array)
        {
            bool swap = true;
            int j = 0;
            while (swap)
            {
                swap = false;
                j++;
                for (int i = 1; i < array.Length + 1 - j; i++)
                {
                    if (string.Compare(array[i - 1], array[i]) == 1 )
                    {
                        string tmp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = tmp;
                        swap = true;
                    }
                }
            }
        }

        static int BinarySearch(int max, int min, ref string[] n, string search)
        {
            int ret = -1;
            int mid = getMid(min, max);
            if (n.Contains(search))
            {
                while (ret == -1)
                {
                    if (string.Compare(n[mid], search) == -1)
                    {
                        min = mid + 1;
                        mid = getMid(min, max);
                    }
                    else if (string.Compare(n[mid],search) == 1)
                    {
                        max = mid - 1;
                        mid = getMid(min, max);

                    }
                    else if (n[mid] == search)
                    {
                        ret = mid;
                    }
                }
            }
            return ret;
        }

        static int getMid(int min, int max)
        {
            return (min + max) / 2;
        }
    }
}
