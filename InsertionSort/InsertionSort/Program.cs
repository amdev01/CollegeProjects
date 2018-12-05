using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 8, 2, 9, 11, 55, 27, 18, 135, 90 };
            printArray(array);
            Console.ReadKey();
            insertionSort(array, array.Length);
            printArray(array);
            Console.ReadKey();

        }

        static void printArray(int[] array)
        {
            string list = "";
            for (int i=0; i<array.Length;i++)
            {
                list += array[i] + ", ";
            }
            Console.WriteLine(list);
        }

        static void insertionSort(int[] array, int n)
        {
            for (int i=1;i<n;i++)
            {
                int j=i-1;
                int tmp = array[i];
                while(j>=0 && tmp<array[j])
                {
                    array[j+1] = array[j];
                    j--;
                }
                array[j+1] = tmp;
            }
        }
    }
}
