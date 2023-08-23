using System.Collections.Generic;
using System;
using System.Linq;

namespace StringCalculatorProject;

public class StringCalculator
{

    //static string sEquation;
    private const string _sOperators = "*/%+-";
    private const string _sDigits = "0123456789.";
    public const int _maxLen = 20;
    
    private static List<double> equationNumbersList = new List<double>();
    private static List<char> equationOperatorsList = new List<char>();


    public (int, string) Calc(string EquationStr)
    {
        if (EquationStr == null || EquationStr.Length > _maxLen || EquationStr.Length < 1) return (-1, $"Given equation is {(EquationStr == null ? null : EquationStr.Length)} characters long, the maximum is {_maxLen}, please re enter the equation");
        if (EquationStr == "help") return (1, getHelp());
        if (getEquation(EquationStr))
        {
            var copyOpsInEq = equationOperatorsList.ToList();
            foreach (char op in copyOpsInEq)
            {
                multiIndex(op);
            }

            if (indexOfOperator('+') == -1 && indexOfOperator('-') == -1)
            {
                return (0, $"{EquationStr}={equationNumbersList[0]}");
            }
            else
            {
                double answer = AddSub(equationNumbersList[0], equationNumbersList[1], equationOperatorsList[0]);
                int opc = 1;
                for (int i = 2; i < equationNumbersList.Count; i++)
                {
                    answer = AddSub(answer, equationNumbersList[i], equationOperatorsList[opc]);
                    opc++;
                }
                return (0, $"{EquationStr}={answer}");
            }
        }
        return (-2, "ERROR: Equation could not have been calculated");
    }

    public string getHelp() =>
        "******************************\n" +
        "** Help Sheet                *\n" +
        "** Functions :               *\n" +
        "** Addition: a+b             *\n" +
        "** Subtraction: a-b          *\n" +
        "** Multiplication: a*b       *\n" +
        "** Division: a/b             *\n" +
        "** Modulus: a%b              *\n" +
        "** Brackets: a*(b+c)         *\n" +
        "** This is the basic syntax  *\n" +
        "** of the calculator, all the*\n" +
        "** functions can be combined *\n" +
        "******************************\n";

    static double AddSub(double num1, double num2, char op)
    {
        switch (op)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            default:
                throw new ArgumentException("Supported operators are '+' and '-' "); // should throw an exception as when this function is called there should be only add/sub in equation
        }
    }

    static void multiIndex(char op)
    {
        if (op == '*' || op == '/' || op == '%')
        {
            int pos;
            if ((pos = indexOfOperator(op)) > -1)
            {
                fixList(pos, op);
            }
        }
    }

    static bool getEquation(string sEquation)
    {
        string stmp = "";

        var cEquation = sEquation.ToCharArray();
        for (int i = 0; i < sEquation.Length; i++)
        {
            if (_sDigits.Contains(cEquation[i].ToString()))
            {
                if (i == sEquation.Length - 1)
                {
                    stmp += cEquation[i].ToString();
                    equationNumbersList.Add(Double.Parse(stmp));
                    stmp = "";
                }
                else
                {
                    stmp += (cEquation[i]).ToString();
                }
            }
            else if (_sOperators.Contains(cEquation[i].ToString()))
            {
                equationOperatorsList.Add(cEquation[i]);
                equationNumbersList.Add(Double.Parse(stmp));
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


    static int indexOfOperator(char op)
    {
        int index = -1;
        for (int i = 0; i < equationOperatorsList.Count; i++)
        {
            if (op == equationOperatorsList[i])
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
                tmphigh = equationNumbersList[opPos] * equationNumbersList[opPos + 1];
                break;
            case '/':
                tmphigh = equationNumbersList[opPos] / equationNumbersList[opPos + 1];
                break;
            case '%':
                tmphigh = equationNumbersList[opPos] % equationNumbersList[opPos + 1];
                break;
            default:
                break;

        }
        equationNumbersList[opPos] = tmphigh;
        equationNumbersList.RemoveAt(opPos + 1);
        equationOperatorsList.RemoveAt(opPos);
    }
}