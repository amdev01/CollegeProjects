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
        static List<int> iNumsInEq = new List<int>();
        static List<char> cOpsInEq = new List<char>();
        static int maxLen = 10, multiPos, divPos, modPos;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the equation you want to work out down below with the maximum of 8 characters in the equation (enter 'help' to display help menu)");
            sEquation = Console.ReadLine();
            while (sEquation.Length > maxLen || sEquation.Length == 0)
            {
                Console.WriteLine("Give equation is {0} characters long, the maximum is {1}, please re enter the equation", (sEquation.Length).ToString(), maxLen.ToString());
                sEquation = Console.ReadLine();
            }

            if (getEquation())
            {
                if ((multiPos = oofIndex('*')) > -1)
                {
                    fixList(multiPos, '*');
                }
                if ((divPos = oofIndex('/')) > -1)
                {
                    fixList(divPos, '/');
                }
                if ((modPos = oofIndex('%')) > -1)
                {
                    fixList(modPos, '%');
                }

                if ((oofIndex('+') == -1 && oofIndex('-') == -1))
                {
                    Console.Clear();
                    Console.WriteLine("{0}={1}", sEquation, iNumsInEq[0].ToString());
                }
                else
                {
                    int answer = AddSub(iNumsInEq[0], iNumsInEq[1], cOpsInEq[0]);
                    int opc = 1;
                    for (int i = 2; i < iNumsInEq.Count; i++)
                    {
                        answer = AddSub(answer, iNumsInEq[i], cOpsInEq[opc]);
                        opc++;
                    }
                    Console.Clear();
                    Console.WriteLine("{0}={1}", sEquation, answer.ToString());
                }
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

        static int AddSub(int num1, int num2, char coperator)
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
                default:
                    break;
            }
            return tmpans;
        }

        static Boolean getEquation()
        {
            string stmp = "";

            char[] cEquation = sEquation.ToCharArray();
            for (int i = 0; i < sEquation.Length; i++)
            {
                if (sDigits.Contains(cEquation[i]))
                {
                    if (i == sEquation.Length - 1)
                    {
                        stmp += (cEquation[i]).ToString();
                        iNumsInEq.Add(Convert.ToInt16(stmp));
                        stmp = "";
                    }
                    else
                    {
                        stmp += (cEquation[i]).ToString();
                    }
                }
                else if (sOperators.Contains(cEquation[i]))
                {
                    cOpsInEq.Add(cEquation[i]);
                    iNumsInEq.Add(Convert.ToInt16(stmp));
                    stmp = "";
                }
                else
                {
                    Console.WriteLine("{0} is not a digit or an operator", Convert.ToString(cEquation[i]));
                    return false;
                }
            }
            return true;
        }

        static int oofIndex(char op)
        {
            int index = -1;
            for (int i = 0; i < cOpsInEq.Count; i++)
            {
                if (op == cOpsInEq[i])
                {
                    index = i;
                }

            }
            return index;
        }

        static void fixList(int opPos, char op)
        {
            int tmphigh = 0;
            switch (op)
            {
                case '*':
                    tmphigh = iNumsInEq[opPos] * iNumsInEq[opPos + 1];
                    break;
                case '/':
                    tmphigh = iNumsInEq[opPos] / iNumsInEq[opPos + 1];
                    break;
                case '%':
                    tmphigh = iNumsInEq[opPos] % iNumsInEq[opPos + 1];
                    break;
                default:
                    break;

            }
            iNumsInEq[opPos] = tmphigh;
            iNumsInEq.RemoveAt(opPos + 1);
            cOpsInEq.RemoveAt(opPos);
        }
    }
}
