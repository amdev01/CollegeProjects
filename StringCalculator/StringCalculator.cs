using System.Collections.Generic;
using System;
using System.Linq;

class StringCalculator
{

    static string sEquation;
    private const string _sOperators = "*/%+-";
    private const string _sDigits = "0123456789.";
    private static List<double> iNumsInEq = new List<double>();
    private static List<char> cOpsInEq = new List<char>();
    public const int _maxLen = 20;


    public string Calc(string EquationStr) {
        if (EquationStr.Length > _maxLen || EquationStr.Length < 1) return $"Give equation is {sEquation.Length} characters long, the maximum is {_maxLen}, please re enter the equation";
        if (getEquation())
            {
                var copyOpsInEq = cOpsInEq.ToList();
                foreach (char op in copyOpsInEq)
                {
                    multiIndex(op);
                }

                if (oofIndex('+') == -1 && oofIndex('-') == -1)
                {
                    return $"{sEquation}={iNumsInEq[0]}";
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
                    return $"{sEquation}={answer}";
                }
            }
        return "ERROR: Equation could not have been calculated";
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
            if (_sDigits.Contains(cEquation[i].ToString()))
            {
                if (i == sEquation.Length - 1)
                {
                    stmp += cEquation[i].ToString();
                    iNumsInEq.Add(Double.Parse(stmp));
                    stmp = "";
                }
                else
                {
                    stmp += (cEquation[i]).ToString();
                }
            }
            else if (_sOperators.Contains(cEquation[i].ToString()))
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
