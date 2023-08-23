using System.Text;
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
                if (op == '*' || op == '/' || op == '%')
                {
                    int index = indexOfOperator(op);
                    if (index > -1) peformHighRankCalc(index, op);
                }
            }

            if (indexOfOperator('+') != -1 && indexOfOperator('-') != -1) //return (0, $"{EquationStr}={equationNumbersList[0]}");
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
        if (op == '+') return num1 + num2;
        if (op == '-') return num1 - num2;
        throw new ArgumentException("Supported operators are '+' and '-' "); // should throw an exception as when this function is called there should be only add/sub in equation
    }

    static bool getEquation(string sEquation)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < sEquation.Length; i++)
        {
            if (_sDigits.Contains(sEquation[i]))
            {
                if (i == sEquation.Length - 1) equationNumbersList.Add(Double.Parse(builder.Append(sEquation[i]).ToString())); //builder.Clear();
                else builder.Append(sEquation[i]);
            }
            else if (_sOperators.Contains(sEquation[i]))
            {
                equationOperatorsList.Add(sEquation[i]);
                equationNumbersList.Add(Double.Parse(builder.ToString()));
                builder.Clear();
            }
            else { Console.WriteLine($"{sEquation[i]} is not a digit or an operator"); return false; }
        }
        return true;
    }

    static int indexOfOperator(char op)
    {
        for (int i = 0; i < equationOperatorsList.Count; i++)
        {
            if (op == equationOperatorsList[i]) return i;
        }
        return -1;
    }

    static void peformHighRankCalc(int opIndex, char op)
    {
        if (op == '*') removeHighRankCalcFromEquation(opIndex, equationNumbersList[opIndex] * equationNumbersList[opIndex + 1]);
        else if (op == '/') removeHighRankCalcFromEquation(opIndex, equationNumbersList[opIndex] / equationNumbersList[opIndex + 1]);
        else if (op == '%') removeHighRankCalcFromEquation(opIndex, equationNumbersList[opIndex] % equationNumbersList[opIndex + 1]);
        else throw new ArgumentException("Supported operators are '*', '/', '%' ");
    }

    static void removeHighRankCalcFromEquation(int opIndex, double result)
    {
        equationNumbersList[opIndex] = result;
        equationNumbersList.RemoveAt(opIndex + 1);
        equationOperatorsList.RemoveAt(opIndex);
    }
}