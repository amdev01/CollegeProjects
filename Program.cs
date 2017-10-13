using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static string sEquation;
        static string sOperators = "*/%+-";
        static string sDigits = "0123456789";
        static int[] iNumsInEquation = new int[8];
        static char?[] cOpsInEquation = new char?[8];
        static int[] properiNumsInEquation = new int[8];
        static char[] propercOpsInEquation = new char[8];
        static bool fail = false;
        static int addPos, subPos, multiPos, divPos, modPos;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the equation you want to work out down below with the maximum of 8 characters in the equation (enter 'help' to display help menu)");
            sEquation = Console.ReadLine();
            while (sEquation.Length > 8)
            {
                Console.WriteLine("Give equation is {0} characters long, the maximum is 8, please re enter the equation", Convert.ToString(sEquation.Length));
                sEquation = Console.ReadLine();
            }

            getEquation();

            
            if (fail == false)
            {
                int answer = twoNumbers(iNumsInEquation[0], iNumsInEquation[1], cOpsInEquation[0]);
                int opc = 1;
                for (int i = 2; iNumsInEquation[i] > 0; i++)
                {
                    answer = twoNumbers(answer, iNumsInEquation[i], cOpsInEquation[opc]);
                    opc++;
                }
                Console.Clear();
                Console.WriteLine("{0}={1}", sEquation, answer.ToString());
            }
            
            Console.Read();
        }

        static void getHelp()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("* Help Sheet                *");
            Console.WriteLine("* Functions :               *");
            Console.WriteLine("* Addition: a+b             *");
            Console.WriteLine("* Subtraction: a-b          *");
            Console.WriteLine("* Multiplication: a*b       *");
            Console.WriteLine("* Division: a/b             *");
            Console.WriteLine("* Modulus: a%b              *");
            Console.WriteLine("* Brackets: a*(b+c)         *");
            Console.WriteLine("* This is the basic syntax  *");
            Console.WriteLine("* of the calculator, all the*");
            Console.WriteLine("* functions can be combined *");
            Console.WriteLine("*****************************");
        }
        static int twoNumbers(int num1, int num2, char? coperator)
        {
            int tmpans = 0;
            switch (coperator)
            {
                case '+':
                    tmpans = num1 + num2;
                    break;
                case '-':
                    tmpans = num1 - num2;
                    break;
                case '*':
                    tmpans = num1 * num2;
                    break;
                case '/':
                    tmpans = num1 / num2;
                    break;
                case '%':
                    tmpans = num1 % num2;
                    break;
                default:
                    break;
            }
            return tmpans;
        }

        static void getEquation()
        {
            string stmp = "";
            int dcounter = 0;
            int ocounter = 0;

            char[] cEquation = sEquation.ToCharArray();
            for (int i = 0; i < sEquation.Length; i++)
            {
                if (sDigits.Contains(cEquation[i]))
                {
                    if (i == sEquation.Length - 1)
                    {
                        stmp += (cEquation[i]).ToString();
                        iNumsInEquation[dcounter] = Convert.ToInt16(stmp);
                        stmp = "";
                        dcounter++;
                    }
                    else
                    {
                        stmp += (cEquation[i]).ToString();
                    }
                }
                else if (sOperators.Contains(cEquation[i]))
                {
                    cOpsInEquation[ocounter] = cEquation[i];
                    ocounter++;
                    iNumsInEquation[dcounter] = Convert.ToInt16(stmp);
                    dcounter++;
                    stmp = "";
                }
                else
                {
                    Console.WriteLine("{0} is not a digit or an operator", Convert.ToString(cEquation[i]));
                    fail = true;
                    break;
                }
            }
        }
        static void bodmansIt()
        {
            for (int i=0; cOpsInEquation[i] != null; i++)
            {
                switch(cOpsInEquation[i])
                {
                    case '/':
                        multiPos=i;
                        break;
                    case '*':
                        divPos=i;
                        break;
                    case '%':
                        modPos=i;
                        break;
                    case '+':
                        addPos=i;
                        break;
                    case '-':
                        subPos = i;
                        break;
                }
            }

        }
    }
}
