using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 8, 9, 3, 6, 2, 7 };
            Console.WriteLine($"Before sort the array is '{printAr(array)}'");
            Console.WriteLine("Sorting . . .");
            BubbleSort(ref array);
            Console.WriteLine($"After sort the array is '{printAr(array)}'");
            Console.ReadKey();
        }

        static string printAr(int[] array)
        {
            string list = "";
            for (int i = 0; i < array.Length; i++)
            {
                list += array[i] + ", ";
            }
            return list;
        }

        static void BubbleSort(ref int[] array)
        {
            bool swap = true;
            int j = 0;
            while(swap)
            {
                swap = false;
                j++;
                for (int i = 1; i < array.Length+1-j; i++)
                {
                    if (array[i-1] > array[i])
                    {
                        int tmp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = tmp;
                        swap = true;
                    }
                }
            }
        }
    }
}
