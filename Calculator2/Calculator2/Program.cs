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
        private const string sOperators = "*/%+-";
        private const string sDigits = "0123456789.";
        static List<double> iNumsInEq = new List<double>();
        static List<char> cOpsInEq = new List<char>();
        private const int maxLen = 20;

        static void Main(string[] args)
        {
            Console.WriteLine($"Enter the equation you want to work out down below with the maximum of {maxLen} characters in the equation (enter 'help' to display help menu)");
            sEquation = Console.ReadLine();
            while (sEquation.Length > maxLen || sEquation.Length == 0)
            {
                Console.WriteLine($"Give equation is {sEquation.Length} characters long, the maximum is {maxLen}, please re enter the equation");
                sEquation = Console.ReadLine();
            }

            if (getEquation())
            {
                var copyOpsInEq = cOpsInEq.ToList();
                foreach (char op in copyOpsInEq)
                {
                    multiIndex(op);
                }

                if ((oofIndex('+') == -1 && oofIndex('-') == -1))
                {
                    Console.Clear();
                    Console.WriteLine($"{sEquation}={iNumsInEq[0]}");
                }
                else
                {
                    double answer = AddSub(iNumsInEq[0], iNumsInEq[1], cOpsInEq[0]);
                    int opc = 1;
                    for (int i = 2; i < iNumsInEq.Count; i++)
                    {
                        answer = AddSub(answer, iNumsInEq[i], cOpsInEq[opc]);
                        opc++;
                    }
                    Console.Clear();
                    Console.WriteLine($"{sEquation}={answer}");
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

        static double AddSub(double num1, double num2, char coperator)
        {
            double tmpans = 0;
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

        static void multiIndex(char op)
        {
            if (op == '*' || op == '/' || op == '%')
            {
                int pos;
                if ((pos = oofIndex(op)) > -1)
                {
                    fixList(pos, op);
                }
            }
        }

        static bool getEquation()
        {
            string stmp = "";

            var cEquation = sEquation.ToCharArray();
            for (int i = 0; i < sEquation.Length; i++)
            {
                if (sDigits.Contains(cEquation[i]))
                {
                    if (i == sEquation.Length - 1)
                    {
                        stmp += (cEquation[i]).ToString();
                        iNumsInEq.Add(Double.Parse(stmp));
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
                    iNumsInEq.Add(Double.Parse(stmp));
                    stmp = "";
                }
                else
                {
                    Console.WriteLine($"{cEquation[i]} is not a digit or an operator");
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
                    break;
                }

            }
            return index;
        }

        static void fixList(int opPos, char op)
        {
            double tmphigh = 0;
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